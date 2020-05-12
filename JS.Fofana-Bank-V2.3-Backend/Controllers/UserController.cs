using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JS.Fofana_Bank_V2._3_Backend.Exceptions;
using JS.Fofana_Bank_V2._3_Backend.Models;
using JS.Fofana_Bank_V2._3_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JS.Fofana_Bank_V2._3_Backend.Controllers
{
    [Authorize]
    [Route("api/v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService iUserSevice)
        {
            userService = iUserSevice;
        }

        [HttpGet("users")]
        public List<User> getAllUsers()
        {
            return userService.getUsers();
        }

        [HttpGet("user")]
        public ActionResult<User> authentication([FromBody] User user)
        {
            throw new Exception("testing");
            return userService.authenticate(user);
        }

        [HttpPost("user")]
        public User createUser([FromBody] User user)
        {
            return userService.authenticate(user);
        }

        [HttpPut("user")]
        public User updateUser([FromBody] User user)
        {
            return userService.updateUser(user);
        }
    }
}
