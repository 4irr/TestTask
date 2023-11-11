using Application.Common.Mappings;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommand : IRequest<Guid>, IMapWith<Meetup>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Place { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMeetupCommand, Meetup>()
                .ForMember(meetup => meetup.Name,
                    opt => opt.MapFrom(command => command.Name))
                .ForMember(meetup => meetup.Description,
                    opt => opt.MapFrom(command => command.Description))
                .ForMember(meetup => meetup.Speaker,
                    opt => opt.MapFrom(command => command.Speaker))
                .ForMember(meetup => meetup.DateTime,
                    opt => opt.MapFrom(command => command.DateTime))
                .ForMember(meetup => meetup.Place,
                    opt => opt.MapFrom(command => command.Place));
        }
    }
}
