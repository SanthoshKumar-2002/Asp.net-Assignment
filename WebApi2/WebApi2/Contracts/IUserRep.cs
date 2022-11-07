using Microsoft.AspNetCore.Mvc;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;

namespace WebApi2.Contracts
{
    public interface IUserRep
    {
        /// <summary>
        /// To add the new user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user id</returns>
        public Guid Create(User user);
        /// <summary>
        /// to Update
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void Update(User user);

        /// <summary>
        /// To Delete the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(Guid id);
        /// <summary>
        /// To upload the file
        /// </summary>
        /// <param name="image"></param>
        /// <returns>IFormFile</returns>
        public string FileUpload(FileModel image);
        /// <summary>
        /// Get the user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        public User GetUsers(Guid id);
        /// <summary>
        /// Get the address by userid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        public List<Address> GetAddress(Guid id);
        /// <summary>
        /// Get the Email by userid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Address</returns>
        public List<Email> GetEmail(Guid id);
        /// <summary>
        /// Get the phone number by userid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Emails</returns>
        public List<PhoneNumber> GetPhoneNumber(Guid id);
        /// <summary>
        /// Get the List of Users
        /// </summary>
        /// <returns>List of Phonenumbers</returns>
        public List<User> GetUsers();
        /// <summary>
        /// Get the count of the database
        /// </summary>
        /// <returns>List of users</returns>
        public int Count();
        /// <summary>
        /// To return guid id of type
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Guid</returns>
        public Guid Match(string s);
        /// <summary>
        /// Find the id in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>

        public User Find(Guid id);
        /// <summary>
        /// To Save the changes in the database
        /// </summary>
        public void Save();
        public string Match2(Guid guid);
    }
}
