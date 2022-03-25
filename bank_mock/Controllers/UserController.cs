using System.Collections.Generic;
using System.Net;
using bank_mock.Core.Models;
using bank_mock.Core.Models.Interfaces;
using bank_mock.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace bank_mock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("get/")]
        public IActionResult GetAll()
        {
            List<User> users = _userService.GetAll();
            if (users.Count == 0)
            {
                return NoContent();
            }

            return Ok(users);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(long id)
        {
            User user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            // TODO
            // aq redirect xoar gavaketo im urlze sadac es uzeri dajdeba?
            // anu /get/da mere am useris id?
            // tu prosta movashoro Ok-shi content, da marto Ok davabruno?
            return Ok(user);
        }
        
        [HttpPut("update")]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return Ok(user);
        }
        
        [HttpDelete("delete")]
        public IActionResult Delete(User user)
        {
            _userService.Delete(user);
            return Ok(user);
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(long id)
        {
            User user = _userService.Get(id);
            _userService.Delete(user);
            return Ok(user);
        }
    }
}












