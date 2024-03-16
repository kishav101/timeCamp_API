﻿using System.Text.Json.Serialization;

namespace timeCamp.CommonLogic.Dtos
{
    public sealed class ForgotPasswordDto
    {
        [JsonPropertyName("Username")]
        public required string Username { get; set; }

        [JsonPropertyName("Password")]
        public required string Password { get; set; }
    }
}