using AutoMapper;
using bank_mock.Core.Models;

namespace bank_mock.Core.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}