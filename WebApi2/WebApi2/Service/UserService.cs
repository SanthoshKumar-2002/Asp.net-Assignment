using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;
using WebApi2.Contracts;

namespace WebApi.Contracts
{

    public class UserService : IUserService
    {
       private readonly IUserRep userRep;

       public UserService(IUserRep userRep)
       {
            this.userRep = userRep;
       }

        //meta data
       public IResult GetMetaData()
       {
            throw new NotImplementedException();
       }

        //create
       public Guid Create(UserDTO user)
       {
             var ob = new User();
             ob.Id = new Guid();
            ob.UserName = user.UserName;
            ob.Password = user.Password;    
             ob.FirstName = user.FirstName;
             ob.LastName = user.LastName;
            ob.CreatedOn = DateTime.Now;
            ob.CreatedBy = user.UserName;
                    ob.IsActive = true;
            List<Address> addresses = new List<Address>();
             for (int i = 0; i < user.Address.Count; i++)
             {
                 var address1 = new Address()
                 {
                     UserId=ob.Id,
                     AddressId=new Guid(),
                     Line1 = user.Address[i].Line1,
                     Line2 = user. Address[i].Line2,
                     City = user. Address[i].City,
                     ZipCode = user.Address[i].ZipCode,
                     State = user.Address[i].State,
                     key = Type(user.Address[i].Type),
                     country = user.Address[i].country,
                     CreatedOn = DateTime.Now,
                     CreatedBy = user.UserName,
                     IsActive = true
                 };
                addresses.Add(address1);
              
             }
            ob.Address = addresses;
            List<Email> email = new List<Email>();
            for (int i = 0; i < user.Email.Count; i++)
            {
                var email1 = new Email()
                {
                    UserId =ob.Id, 
                    EmailId=new Guid(),
                    EmailAddress = user.Email[i].EmailAddress,
                   key = Type(user.Email[i].Type),
                    CreatedOn = DateTime.Now,
                    CreatedBy = user.UserName,
                    IsActive = true
                };
               email.Add(email1);
            }
            ob.Email=email;
            List<PhoneNumber> phone = new List<PhoneNumber>();
            for (int i = 0; i < user.phoneNumber.Count; i++)
            {
                var phone1 = new PhoneNumber()
                {
                    UserId = ob.Id,
                    phoneId = new Guid(),
                    _phoneNumber = user.phoneNumber[i]._phoneNumber,
                    key = Type(user.phoneNumber[i].Type),
                    CreatedOn = DateTime.Now,
                    CreatedBy = user.UserName,
                    IsActive = true
                };
                phone.Add(phone1);
            }
            ob.phoneNumber=phone;
               
             var res=userRep.Create(ob);
            userRep.Save();
            return res;
       }

        //get all the users
        public IEnumerable<UserDTO> GetAll()
        {

            List<UserDTO> userDTOs = new List<UserDTO>();

            List<User> user = userRep.GetUsers();
            for (int i = 0; i < user.Count; i++)
            {
                UserDTO dis = new UserDTO();
                if (user[i].IsActive != true)
                    continue;
                
                dis.FirstName = user[i].FirstName;
                dis.LastName = user[i].LastName;
                dis.Address = new List<AddressDTO>();
                dis.Email = new List<EmailDTO>();
                dis.phoneNumber = new List<PhoneNumberDTO>();
                List<Address> address = userRep.GetAddress(user[i].Id);
                for (int j = 0; j < address.Count; j++)
                {
                    AddressDTO address2 = new AddressDTO()
                    {
                        Line1 = address[j].Line1,
                        Line2 = address[j].Line2,
                        State = address[j].State,
                        ZipCode = address[j].ZipCode,
                        City = address[j].City,
                        country = address[j].country,
                        Type = Type2(address[j].key)
                    };
                    dis.Address.Add(address2);
                }
                List<Email> emails = userRep.GetEmail(user[i].Id);
                for (int j = 0; j < emails.Count; j++)
                {
                    EmailDTO emailDTO = new EmailDTO()
                    {
                        EmailAddress = emails[j].EmailAddress,
                        Type = Type2(emails[j].key)
                    };
                    dis.Email.Add(emailDTO);
                }
                List<PhoneNumber> phoneNumbers = userRep.GetPhoneNumber(user[i].Id);
                for (int j = 0; j < phoneNumbers.Count; j++)
                {
                    PhoneNumberDTO phoneNumberDTO = new PhoneNumberDTO()
                    {
                        _phoneNumber = phoneNumbers[j]._phoneNumber,
                        Type = Type2(phoneNumbers[j].key)
                    };
                    dis.phoneNumber.Add(phoneNumberDTO);
                }
                userDTOs.Add(dis);
            }
            return userDTOs;
        }

        //Count
        public int GetCount()
        {
            return userRep.Count();
        }

        // get by id
        public UserDTO GetId(Guid id)
        {
            UserDTO user = new UserDTO();
            User find = userRep.Find(id);
            user.UserName=find.UserName;
            user.FirstName = find.FirstName;
            user.LastName = find.LastName;
            user.Address = new List<AddressDTO>();
            user.Email = new List<EmailDTO>();
            user.phoneNumber = new List<PhoneNumberDTO>();
            List<Address> addresses = userRep.GetAddress(id);

            for (int i = 0; i < addresses.Count; i++)
            {
                AddressDTO address1 = new AddressDTO()
                {

                    Line1 = addresses[i].Line1,
                    Line2 = addresses[i].Line2,
                    City = addresses[i].City,
                    ZipCode = addresses[i].ZipCode,
                    State = addresses[i].State,
                    Type = Type2(addresses[i].key),
                    country = addresses[i].country
                };
                user.Address.Add(address1);

            }
            List<Email> email = userRep.GetEmail(id);
            for (int i = 0; i < email.Count; i++)
            {
                var email1 = new EmailDTO()
                {
                    EmailAddress = email[i].EmailAddress,
                    Type = Type2(email[i].key)
                };
                user.Email.Add(email1);
            }
            List<PhoneNumber> phoneNumbers = userRep.GetPhoneNumber(id);
            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                var phoneNumber1 = new PhoneNumberDTO()
                {
                    _phoneNumber = phoneNumbers[i]._phoneNumber,
                    Type = Type2(phoneNumbers[i].key)
                };
                user.phoneNumber.Add(phoneNumber1);
            }
            if((bool)find.IsActive)
            return user;
            return null;

        }

        //update
        public IResult Update(Guid id, UserDTO user)
        {
            var ob = userRep.Find(id);
            if (ob != null)
            {

                ob.FirstName = user.FirstName;
                ob.LastName = user.LastName;
                ob.UpdatedOn = DateTime.Now;
                ob.UpdateBy = user.UserName;
                ob.Address = new List<Address>();
                ob.Email = new List<Email>();
                ob.phoneNumber = new List<PhoneNumber>();
                List<Address> addresses = new List<Address>();
                for (int i = 0; i < user.Address.Count; i++)
                {
                    var address1 = new Address()
                    {

                        Line1 = user.Address[i].Line1,
                        Line2 = user.Address[i].Line2,
                        City = user.Address[i].City,
                        ZipCode = user.Address[i].ZipCode,
                        State = user.Address[i].State,
                        key = Type(user.Address[i].Type),
                        country = user.Address[i].country,
                         UpdatedOn = DateTime.Now,
                         UpdateBy = user.UserName,
                         IsActive=true
                };
                    addresses.Add(address1);

                }
                ob.Address = addresses;
                List<Email> email = new List<Email>();
                for (int i = 0; i < user.Email.Count; i++)
                {
                    var email1 = new Email()
                    {

                        EmailAddress = user.Email[i].EmailAddress,
                        key = Type(user.Email[i].Type),
                        UpdatedOn = DateTime.Now,
                        UpdateBy = user.UserName,
                        IsActive = true
                    };
                    email.Add(email1);
                }
                ob.Email = email;
                List<PhoneNumber> phone = new List<PhoneNumber>();
                for (int i = 0; i < user.phoneNumber.Count; i++)
                {
                    var phone1 = new PhoneNumber()
                    {

                        _phoneNumber = user.phoneNumber[i]._phoneNumber,
                        key = Type(user.phoneNumber[i].Type),
                        UpdatedOn = DateTime.Now,
                        UpdateBy = user.UserName,
                        IsActive = true
                    };
                    phone.Add(phone1);
                }
                ob.phoneNumber = phone;
                userRep.Update(ob);
               userRep.Save();
                return Results.Ok();
            }
            return Results.NotFound();
        }

        //delete
        public IResult Delete(Guid id)
        {
            var delete = userRep.Delete(id);
            userRep.Save();
                return Results.Ok();
            return Results.NotFound();
        }

        //file upload
        public IFormFile FileUpload(FileModelDTO image)
        {
            IFormFile file = image.FormFile;
            FileModel fileModel = new FileModel();
            fileModel.id = new Guid();
             byte[] GetBytes(IFormFile formFile)
            {
                 using var memoryStream = new MemoryStream();
                 formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
            var bytes = GetBytes(file);

            fileModel.FormFile = bytes;

            var res=userRep.FileUpload(fileModel);
            userRep.Save();
            return image.FormFile;
        }

        //file download
        public IResult FileDownload(Guid id)
        {
            throw new NotImplementedException();
        }

        //convert string to guid
        public Guid Type(string type)
        {
            type.ToUpper();
            var guid = userRep.Match(type);
            if(guid==null)
            {
                return Guid.Empty;
            }
            
            return guid;
        }

        //convert guid to string
        public string Type2(Guid guid)
        {
            var s=userRep.Match2(guid);
            if(s==null) 
                return string.Empty;
            return s;
        }
    }
        }
