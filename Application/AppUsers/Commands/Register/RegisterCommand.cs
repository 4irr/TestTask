using Application.Common.Mappings;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.AppUsers.Commands.Register
{
    public class RegisterCommand : IRequest<string>, IMapWith<AppUser>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? DisplayName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterCommand, AppUser>()
                .ForMember(user => user.UserName,
                    opt => opt.MapFrom(command => command.Username))
                .ForMember(user => user.DisplayName,
                    opt => opt.MapFrom(command => command.DisplayName));
        }
    }
}
