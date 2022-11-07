using WebApi.Entities.DTO;

namespace WebApi.Services
{
    public interface IUserServices
    {
        public bool Authenticate(UserLoginDTO userLoginDTO); 
    }
}