using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaaSBackend.Domain.Entities;
using SaaSBackend.Infrastructure.Context;


namespace SaaSBackend.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FirmaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
    

        public FirmaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var firmalar = await _context.Firmalar.ToListAsync();
            return Ok(firmalar);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var firma = await _context.Firmalar.FindAsync(id);
            if(firma == null)
            {
                return NotFound();
            }
            return Ok(firma);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Firma firma)
        {
            _context.Firmalar.Add(firma);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = firma.Id}, firma);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Firma updatedFirma)
        {
            var firma = await _context.Firmalar.FindAsync(id);
            if (firma == null)
                return NotFound();

            firma.Ad = updatedFirma.Ad;
            firma.VergiNo = updatedFirma.VergiNo;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var firma = await _context.Firmalar.FindAsync(id);
            if (firma == null)
                return NotFound();

            _context.Firmalar.Remove(firma);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("gizli")]
        [Authorize(Roles = "Admin")]
        public IActionResult SadeceAdmin()
        {
            return Ok("Bu mesaj sadece Admin'lere gösterilir.");
        }

    }
}
