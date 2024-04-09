using AutoMapper;
using UsersAPI.Dto;
using UsersAPI.Models;

namespace UsersAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
