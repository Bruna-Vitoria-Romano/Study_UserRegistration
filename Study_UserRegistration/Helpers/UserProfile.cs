using Study_UserRegistrationLibrary.Entities;
using Study_UserRegistrationLibrary.Entities.DTOs;
using AutoMapper;

namespace Study_UserRegistration.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserCreateUpdateDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
