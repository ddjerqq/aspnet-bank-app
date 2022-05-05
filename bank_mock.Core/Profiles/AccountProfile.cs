using AutoMapper;
using bank_mock.Core.Models;

namespace bank_mock.Core.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(dest=>dest.UserId, 
                    opt=>
                        opt.MapFrom(src=>src.User.Id))
                .ForMember(dest=>dest.User, 
                    opt=>
                        opt.MapFrom(src=>src.User));
            
            CreateMap<AccountDto, Account>()
                .ForMember(dest=>dest.User, 
                    opt=>
                        opt.MapFrom(src=>src.User))
                .ForMember(dest=>dest.UserId, 
                    opt=>
                        opt.MapFrom(src=>src.UserId));
        }   
    }
}