using WebApi.Entities.Models;
using WebApi2.Entities.DTO;

namespace WebApi.Entities.DTO
{
    public class AddressDTO
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public string country { get; set; }
    }
}
