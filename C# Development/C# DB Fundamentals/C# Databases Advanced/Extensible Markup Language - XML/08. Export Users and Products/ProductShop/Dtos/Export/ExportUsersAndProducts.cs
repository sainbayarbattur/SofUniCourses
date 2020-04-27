using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportUsersAndProducts
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserDTO[] Users { get; set; }
    }
}
