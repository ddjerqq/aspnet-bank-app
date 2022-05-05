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
        public async Task<IActionResult> GetAll()
        {
            List<Account> accounts = await _accountService.GetAllAsync();
            
            if (accounts.Count == 0)
            {
                return NoContent();
            }

            var accountDtos = _mapper.Map<IEnumerable<AccountDto>>(accounts);
            return Ok(accountDtos);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            Account account = await _accountService.GetAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            var accountDto = _mapper.Map<AccountDto>(account);
            return Ok(accountDto);
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> Add(AccountCreateDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            await _accountService.AddAsync(account);
            return Ok();
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> Update(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            await _accountService.UpdateAsync(account);
            return Ok();
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Account account = await _accountService.GetAsync(id);
            await _accountService.DeleteAsync(account);
            return Ok();
        }
    }
}