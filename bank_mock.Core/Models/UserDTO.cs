using System.Collections.Generic;
using AutoMapper;

namespace bank_mock.Core.Models
{
    public class UserDto
    { 
        public string Username { get; set; }
        public ICollection<AccountDto> AccountDtos { get; set; }
    }
}