using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string user_name { get; set; }
        [Required]
        public string password { get; set; }
    }
}
