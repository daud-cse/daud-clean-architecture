using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Services.Interfaces.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Description;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNet.WebApi.Controllers.Common
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        [ResponseType(typeof(ResponseMessage))]
        public ResponseMessage GetAll()
        {
            //try
            //{
            //    var response = await this._userService.GetAll();
            //    if (response != null)
            //    {
            //        return Ok(response);
            //    }
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}
            //catch (Exception ex)
            //{
            //    //_logger.LogError(ex, ex.Message);
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}
            return _userService.GetAll();
        }

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        [HttpGet, AllowAnonymous]
        [Route("getByID/{id}")]
        [ResponseType(typeof(ResponseMessage))]
        public ResponseMessage GetByID(int id)
        {
            return _userService.GetByID(id);
        }

        [HttpPost("add")]
        [ResponseType(typeof(ResponseMessage))]
        public ResponseMessage Post(RequestMessage reqMes)
        {
            Users user = JsonConvert.DeserializeObject<Users>(reqMes.RequestObj.ToString());
            return _userService.Add(user);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
