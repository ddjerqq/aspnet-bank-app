using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAll()
        {
            List<User> users = await _userService.GetAllAsync();
            
            if (users.Count == 0)
            {
                return NoContent();
            }

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            User user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.AddAsync(user);
            return Ok();
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.UpdateAsync(user);
            return Ok();
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            User user = await _userService.GetAsync(id);
            await _userService.DeleteAsync(user);
            return Ok();
        }
    }
}
