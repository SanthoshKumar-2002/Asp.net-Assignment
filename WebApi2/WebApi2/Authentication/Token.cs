using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Authentication;
using WebApi.Entities.DTO;
namespace WebApi.Services
{
    public class Token : IToken
    {
        private readonly IConfiguration _configuration;
        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       public string TokenGenerator(UserLoginDTO user)
        {
            var loggedUser = user;
            if (loggedUser == null) return null;
            UserServices userService = new UserServices();
            if (userService.Authenticate(user)!=true)
                return null ;


            var claim = new[]
         {
            new Claim(ClaimTypes.NameIdentifier,loggedUser.user_name),
             new Claim(ClaimTypes.NameIdentifier,loggedUser.password)
        };
            var token = new JwtSecurityToken
            (
                issuer:_configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(15),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256)
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
    
            return (@"access_token  "+ tokenString+
                     "       token type : Bearer");
        }
    }
    }
