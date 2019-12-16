using AutoMapper;
using Med_Center_API.Dtos;
using Med_Center_API.Models;

namespace Med_Center_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForUpdateDto>(MemberList.Destination);
            CreateMap<UserForUpdateDto, User>(MemberList.Destination);
        }
    }
}