using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authentication;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;
using WebApi.Services;
using WebApi2.Entities;

namespace WebApi2.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Address_Book_AuthenticateController : ControllerBase
    {
        private readonly ApiDbContext dp;
        private readonly IToken token;
        private readonly IUserServices userService;
        public Address_Book_AuthenticateController(IToken token, IUserServices userService, ApiDbContext dp)
        {
            this.token = token;
            this.userService = userService;
            this.dp = dp;
        }
        [HttpPost]
        [Route("auth/sign")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (userService.Authenticate(userLoginDTO) != true)
            {
                return Unauthorized();
            }
            return Ok(token.TokenGenerator(userLoginDTO));
        }
    }
}
