using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SaaSBackend.Domain.Entities;
using SaaSBackend.Infrastructure.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using SaaSBackend.API.Settings;

namespace SaaSBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtSettings? _jwtSettings;

        public AuthController(ApplicationDbContext context, IOptions<JwtSettings> jwtOptions)
        {
            _context = context;
            _jwtSettings = jwtOptions.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Kullanici kullanici)
        {
            var mevcut = await _context.Kullanicilar
                .AnyAsync(x => x.KullaniciAdi == kullanici.KullaniciAdi);

            if (mevcut)
                return BadRequest("Bu kullanıcı adı zaten alınmış!");

            kullanici.SifreHash = HashSifre(kullanici.SifreHash ?? "");

            _context.Kullanicilar.Add(kullanici);
            await _context.SaveChangesAsync();

            return Ok("Kayıt başarılı!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Kullanici giris)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(x => x.KullaniciAdi == giris.KullaniciAdi);

            if (kullanici == null)
                return Unauthorized("Kullanıcı bulunamadı");

            var girilenSifreHash = HashSifre(giris.SifreHash ?? "");

            if (kullanici.SifreHash != girilenSifreHash)
                return Unauthorized("Şifre yanlış");

            var token = GenerateJwtToken(kullanici);
            return Ok(new { token });
        }

        private string GenerateJwtToken(Kullanici kullanici)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, kullanici.KullaniciAdi ?? ""),
        new Claim(ClaimTypes.Role, kullanici.Rol ?? "Kullanici")
    };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Expires),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        private string HashSifre(string sifre)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(sifre);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
