using System.Text.Json.Serialization;

namespace assogw.Models
{
    public class DealershipModel
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("State")]
        public string State { get; set; }

        [JsonPropertyName("Zip")]
        public string Zip { get; set; }

        [JsonPropertyName("Phone")]
        public string Phone { get; set; }

        [JsonPropertyName("Whatsapp")]
        public string Whatsapp { get; set; }
    }
}
