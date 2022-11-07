using WebApi.Entities.DTO;

namespace WebApi2.Entities.DTO
{
    public class UpdateDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EmailDTO> Email { get; set; }
        public List<AddressDTO> Address { get; set; }
        public List<PhoneNumberDTO> phoneNumber { get; set; }
    }
}
