using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Authorization;
using WebApi.Entities.Models;
using WebApi.Entities.DTO;
using WebApi.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using WebApi.Authentication;
using WebApi2.Contracts;
using WebApi2.Entities;
using WebApi2.Repository;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json.Linq;
using WebApi2.Entities.DTO;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/")]
    
    public class AddressBookApiController : Controller
        {
          private readonly IUserService userContract;
      
        public AddressBookApiController(IUserService userContract)
        {
            this.userContract = userContract;
        }
       

       
        // meta data
        [HttpGet]
           [Route("/api/meta-data/ref-set/{key}")]
           public IResult ApiMetaDataRefSetKeyGet([FromRoute][Required] string key)
           {

               return Results.Ok();
           } 

        // create account
        [HttpPost]
        [Route("account")]
       
        public IActionResult CreateUser([FromBody] UserDTO user)
        {

            return Ok(userContract.Create(user));
        }


        // get all the user
       [HttpGet]
        [Route("account")]
        public IEnumerable ApiAccountGet()
        {
            return userContract.GetAll();
        }

        // get the count
            [HttpGet]
            [Route("account/count")]
            public virtual IResult ApiAccountCountGet()
            {
            return Results.Ok(userContract.GetCount());
        }

        //get by id
            [HttpGet]
            [Route("account/{id}")]
            public  UserDTO GetById([FromRoute][Required] Guid id)
            {
            return userContract.GetId(id);
            }
        //update
        [HttpPut]
        [Route("/api/account/Guid {id}")]

        public virtual IResult Update([FromRoute][Required] Guid id, [FromBody] UserDTO body)
        {
            return userContract.Update(id, body);
        }

        //delete
          [HttpDelete]
          [Route("/api/account/{id}")]
             public virtual IActionResult Delete([FromRoute][Required] int? id)
              {
            return null;
        }

        //file upload
        [HttpPost]
        [Route("/api/asset/uploadFile")]
        public virtual IResult FileUpload([FromForm] FileModelDTO body)
        {
          var ob=userContract.FileUpload(body); 
            
            return Results.Ok(ob);
        }

        //file download
        [HttpGet]
            [Route("/api/asset/downloadFile/{id}")]
            
            public virtual IActionResult ApiAssetDownloadFileIdGet([FromRoute][Required] int? id)
            {
            return null;
        }
       
    }
}
