using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Meetups.Queries.GetMeetupsList
{
    public class MeetupLookupDto : IMapWith<Meetup>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Place { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupLookupDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(meetup => meetup.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(meetup => meetup.Name))
                .ForMember(dto => dto.Description,
                    opt => opt.MapFrom(meetup => meetup.Description))
                .ForMember(dto => dto.Speaker,
                    opt => opt.MapFrom(meetup => meetup.Speaker))
                .ForMember(dto => dto.DateTime,
                    opt => opt.MapFrom(meetup => meetup.DateTime))
                .ForMember(dto => dto.Place,
                    opt => opt.MapFrom(meetup => meetup.Place));
        }
    }
}
