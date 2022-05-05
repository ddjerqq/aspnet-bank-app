using AutoMapper;
using bank_mock.Core.Models;

namespace bank_mock.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest=>dest.Accounts, 
                    opt
                        =>opt.MapFrom((src=>src.Accounts)));
            
            CreateMap<UserDto, User>()
                .ForMember(dest=>dest.Accounts,
                    opt
                        =>opt.MapFrom((src=>src.Accounts)));
        }
    }
}