using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;

namespace WebApi2.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// To get the meta data
        /// </summary>
        /// <returns></returns>
        public IResult GetMetaData();


        /// <summary>
        /// Create a new user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Guid Create(UserDTO user);


        /// <summary>
        /// Get all the user from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDTO> GetAll();


        /// <summary>
        /// Get the count of the database
        /// </summary>
        /// <returns></returns>
        public int GetCount();


        /// <summary>
        /// To update the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public IResult Update(Guid id,UserDTO user);


        /// <summary>
        /// Get the user details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDTO GetId(Guid id);


       /// <summary>
       /// Delete the use record
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public IResult Delete(Guid id);


        /// <summary>
        /// To upload the file in the database
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public IFormFile FileUpload(FileModelDTO image);


        /// <summary>
        /// To download the file from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResult FileDownload(Guid id);

    }
}
