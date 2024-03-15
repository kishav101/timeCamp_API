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

        [JsonPropertyName("Address")]
        public Address? Address { get; set; }
    }
}