﻿

using System.Text.Json.Serialization;

namespace timeCamp.CommonLogic.Dtos
{
    public sealed class LoginDto
    {
        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName ("password")]
        public required string Password { get; set; }
    }
}
