using AutoMapper;
using bank_mock.Core.Models;

namespace bank_mock.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}