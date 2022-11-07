using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Serialization;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;
using WebApi2.Contracts;
using WebApi2.Entities;

namespace WebApi2.Repository
{
    public class UserRep : IUserRep
    {
        private readonly ApiDbContext dp;
        public UserRep(ApiDbContext context)
        {
            dp = context;
        }
        

        // to add the new user
        public Guid Create(User user)
        {
            dp.Users.Add(user);
          
            return user.Id;
        }
        public User GetId(Guid id)
        {
            var user = dp.Users.FirstOrDefault(o => o.Id == id);
            if (user == null) return null;
            return null;
        }
        public Guid GetAll(User user)
        {
            dp.Users.Add(user);
           
            return user.Id;
        }

        public bool Delete(Guid id)
        {
            var OldMovie = dp.Users.FirstOrDefault(o => o.Id == id);
            if (OldMovie == null) return false;
            OldMovie.IsActive=false;
            return true;
        }

        public string FileUpload(FileModel image)
        {
            dp.Files.Add(image);
              
            return "success";
        }

        // for user
       public User GetUsers(Guid id)
        {
            User user = dp.Users.FirstOrDefault(o => o.Id == id);
           
            return user;
        }

        //for address
        public List<Address> GetAddress(Guid id) { 
            List<Address> addresses = new List<Address>();
                   foreach(Address i in dp.Addresses)
            {
                if(i.UserId==id)
                {
                    addresses.Add(i);
                }
            }
                   return addresses;
        }

        //for email
        public List<Email> GetEmail(Guid id)
        {
            Email email = dp.emails.FirstOrDefault(o => o.UserId == id);
            List<Email> email1 = new List<Email>();
            foreach (Email i in dp.emails)
            {
                if (i.UserId == id)
                {
                    email1.Add(i);
                }
            }
            return email1;
        }

        // for PhoneNumber
        public List<PhoneNumber> GetPhoneNumber(Guid id)
        {
            PhoneNumber phoneNumber = dp.phoneNumbers.FirstOrDefault(o => o.UserId == id);
            List<PhoneNumber> phoneNumbers1 = new List<PhoneNumber>();
            foreach (PhoneNumber i in dp.phoneNumbers)
            {
                if(i.UserId == id)  
                    phoneNumbers1.Add(i);
            }
            return phoneNumbers1;
        }


        // for count
        public int Count()
        {
            return dp.Users.Count();
        }

        // to find
        public User Find(Guid id)
        {
           var ob=dp.Users.FirstOrDefault(o => o.Id == id);
            return ob;
        }
       
        //to save
        public void Save()
        {
            dp.SaveChanges();
        }

        //get all the users
        public List<User> GetUsers()
        {
           List<User> users =dp.Users.ToList();
            return users;
        }

        
        public Guid Match(string s)
        {
            var ob = dp.refSets.FirstOrDefault(o => o.Name.Equals(s));
            if (ob != null)
            return ob.RefSetId;
            return Guid.Empty;
           
        }
        public string Match2(Guid guid)
        {
            var ob=dp.refSets.FirstOrDefault(o=>o.RefSetId.Equals(guid));
            if(ob != null)
            return ob.Name; 
            return "Null"; 
        }

        public void Update(User user)
        {
            dp.Users.Update(user);
        }
    }
}
