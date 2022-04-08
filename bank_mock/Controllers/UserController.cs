using System.Collections.Generic;
using AutoMapper;
using bank_mock.Core.Models;
using bank_mock.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace bank_mock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        [HttpGet("get/")]
        public IActionResult GetAll()
        {
            List<User> users = _userService.GetAll();
            
            if (users.Count == 0)
            {
                return NoContent();
            }

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(long id)
        {
            User user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost("add")]
        public IActionResult Add(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userService.Add(user);
            return Ok();
        }
        
        [HttpPut("update")]
        public IActionResult Update(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userService.Update(user);
            return Ok();
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(long id)
        {
            User user = _userService.Get(id);
            _userService.Delete(user);
            return Ok();
        }
    }
}
