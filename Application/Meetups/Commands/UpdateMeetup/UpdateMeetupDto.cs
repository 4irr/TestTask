using Application.Common.Mappings;
using AutoMapper;

namespace Application.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupDto : IMapWith<UpdateMeetupCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Place { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMeetupDto, UpdateMeetupCommand>()
                .ForMember(command => command.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(command => command.Speaker,
                    opt => opt.MapFrom(dto => dto.Speaker))
                .ForMember(command => command.DateTime,
                    opt => opt.MapFrom(dto => dto.DateTime))
                .ForMember(command => command.Place,
                    opt => opt.MapFrom(dto => dto.Place));
        }
    }
}
