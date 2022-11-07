using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.PortableExecutable;
using WebApi.Contracts;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;

namespace WebApi.Services
{
    public class UserServices :IUserServices
    {
        public bool Authenticate(UserLoginDTO userLoginDTO)
        {
           var user=ddd.FirstOrDefault(x=> x.UserName.Equals(userLoginDTO.user_name)&& (x.Password==userLoginDTO.password));
            if(user==null)
                return false;
            return true;
        }
        private List<UserLogin> ddd = new List<UserLogin>()
        {
            new UserLogin()
            {
                UserName = "peter",
                Password = "peter@123"
            },
            new UserLogin()
            {
                UserName = "thanos",
                Password = "thanos@123"
            }
        };
    }
}

