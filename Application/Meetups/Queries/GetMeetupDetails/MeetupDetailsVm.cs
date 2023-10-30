using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Meetups.Queries.GetMeetupsDetails
{
    public class MeetupDetailsVm : IMapWith<Meetup>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Place { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupDetailsVm>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(meetup => meetup.Id))
                .ForMember(vm => vm.Name,
                    opt => opt.MapFrom(meetup => meetup.Name))
                .ForMember(vm => vm.Description,
                    opt => opt.MapFrom(meetup => meetup.Description))
                .ForMember(vm => vm.Speaker,
                    opt => opt.MapFrom(meetup => meetup.Speaker))
                .ForMember(vm => vm.DateTime,
                    opt => opt.MapFrom(meetup => meetup.DateTime))
                .ForMember(vm => vm.Place,
                    opt => opt.MapFrom(meetup => meetup.Place));
        }
    }
}
