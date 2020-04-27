namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarsFromMakeBMWDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string model { get; set; }

        [XmlAttribute("travelled-distance")]
        public int TravelledDistance { get; set; }
    }
}
