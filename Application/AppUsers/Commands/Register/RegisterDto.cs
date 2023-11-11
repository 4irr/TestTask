using Application.Common.Mappings;
using AutoMapper;

namespace Application.AppUsers.Commands.Register
{
    public class RegisterDto : IMapWith<RegisterCommand>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? DisplayName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterDto, RegisterCommand>()
                .ForMember(command => command.Username,
                    opt => opt.MapFrom(dto => dto.Username))
                .ForMember(command => command.Password,
                    opt => opt.MapFrom(dto => dto.Password))
                .ForMember(command => command.PasswordConfirm,
                    opt => opt.MapFrom(dto => dto.PasswordConfirm))
                .ForMember(command => command.DisplayName,
                    opt => opt.MapFrom(dto => dto.DisplayName));
        }
    }
}
