using System.Collections.Generic;
using AutoMapper;
using bank_mock.Core.Models;
using bank_mock.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace bank_mock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpGet("get/")]
        public IActionResult GetAll()
        {
            List<Account> accounts = _accountService.GetAll();
            
            if (accounts.Count == 0)
            {
                return NoContent();
            }

            var accountDtos = _mapper.Map<IEnumerable<AccountDto>>(accounts);
            return Ok(accountDtos);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(long id)
        {
            Account account = _accountService.Get(id);
            if (account == null)
            {
                return NotFound();
            }

            var accountDto = _mapper.Map<AccountDto>(account);
            return Ok(accountDto);
        }
        
        [HttpPost("add")]
        public IActionResult Add(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            _accountService.Add(account);
            return Ok();
        }
        
        [HttpPut("update")]
        public IActionResult Update(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            _accountService.Update(account);
            return Ok();
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(long id)
        {
            Account account = _accountService.Get(id);
            _accountService.Delete(account);
            return Ok();
        }
    }
}
















