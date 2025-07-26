﻿using Microsoft.AspNetCore.Mvc;

namespace SaaSBackend.API.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int Expires { get; set; }
    }
}

