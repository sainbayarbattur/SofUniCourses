namespace ProductShop.Dtos.Import
{
    using ProductShop.Models;
    using System.Xml.Serialization;

    [XmlType("User")]
    [XmlRoot("Users")]
    public class ImportUserDTO
    {
        [XmlElement("firstName")]
        public string FirtsName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }
    }
}
