using Newtonsoft.Json;

namespace CarDealer.DTO
{
    public class SaleDTO
    {
        [JsonProperty("car")]
        public CarDTO Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
    }
}
