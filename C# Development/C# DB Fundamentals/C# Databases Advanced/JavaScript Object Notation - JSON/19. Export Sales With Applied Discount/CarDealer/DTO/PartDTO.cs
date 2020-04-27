using Newtonsoft.Json;

namespace CarDealer.DTO
{
    public class PartDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
