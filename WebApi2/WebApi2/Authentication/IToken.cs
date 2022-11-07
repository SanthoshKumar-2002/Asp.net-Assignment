using WebApi.Entities.DTO;

namespace WebApi.Authentication
{
    public interface IToken
    {
        public string TokenGenerator(UserLoginDTO user);
    }
}
