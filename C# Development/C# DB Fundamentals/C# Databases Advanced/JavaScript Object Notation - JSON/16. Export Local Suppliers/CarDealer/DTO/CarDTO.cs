using CarDealer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarDTO
    {
        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("travelledDistance")]
        public long TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        public int[] PartsId { get; set; }
    }
}
