using System.Text.Json.Serialization;
using timeCamp.CommonLogic.Modal;

namespace timeCamp.CommonLogic.Dtos
{
    public sealed class AddUserDto
    {
        [JsonPropertyName("Username")]
        public required string Username { get; set; }

        [JsonPropertyName("Password")]
        public required string Password { get; set; }

        [JsonPropertyName("Firstname")]
        public required string Firstname { get; set; }

        [JsonPropertyName("Lastname")]
        public required string Lastname { get; set; }

        [JsonPropertyName("ProfilePhotoPath")]
        public required string ProfilePhotoPath { get; set; }

        [JsonPropertyName("Email")]
        public required string Email { get; set; }

        [JsonPropertyName("CreatedAt")]
        public required string CreatedAt { get; set; } = DateTime.Now.ToString();

        [JsonPropertyName("ModifiedAt")]
        public required string ModifiedAt { get; set; } = DateTime.Now.ToString();

        [JsonPropertyName("RemovedAt")]
        public required string RemovedAt { get; set; } = DateTime.Now.ToString();

    
    }
}