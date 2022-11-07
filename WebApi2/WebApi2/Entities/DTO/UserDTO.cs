using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Linq;
using WebApi.Entities.Models;

namespace WebApi.Entities.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EmailDTO>? Email { get; set; }
        public List<AddressDTO>? Address { get; set; }
        public List<PhoneNumberDTO> phoneNumber { get; set; }
    }
}
