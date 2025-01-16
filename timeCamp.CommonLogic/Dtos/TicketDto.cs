using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace timeCamp.CommonLogic.Dtos
{
    public sealed class TicketDto
    {
        [JsonPropertyName("Title")]
        public required string Title { get; set; }

        [JsonPropertyName("Description")]
        public required string Description { get; set; }

        [JsonPropertyName("Location")]
        public required string Location { get; set; }

        [JsonPropertyName("ContactNumber")]
        public required string ContactNumber { get; set; }

        [JsonPropertyName("Updates")]
        public required string Updates { get; set; }

        [JsonPropertyName("TimeOpened")]
        public required DateTime TimeOpened { get; set; }

        [JsonPropertyName("TimeClosed")]
        public required DateTime TimeClosed { get; set; }


        [JsonPropertyName("CreatedAt")]
        public required string CreatedAt { get; set; } = DateTime.Now.ToString();

        [JsonPropertyName("ModifiedAt")]
        public required string ModifiedAt { get; set; } = DateTime.Now.ToString();

        [JsonPropertyName("RemovedAt")]
        public required string RemovedAt { get; set; } = DateTime.Now.ToString();
    }
}
