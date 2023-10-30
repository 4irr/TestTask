using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.AppUsers.Queries.Login
{
    public class AppUserDto : IMapWith<AppUser>
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Token { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, AppUserDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(dto => dto.DisplayName,
                    opt => opt.MapFrom(user => user.DisplayName));
        }
    }
}
