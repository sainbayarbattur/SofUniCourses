namespace CarDealer.DTO
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class CarPartsDTO
    {
        [JsonProperty("car")]
        public CarDTO Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<PartDTO> Parts { get; set; }
    }
}
