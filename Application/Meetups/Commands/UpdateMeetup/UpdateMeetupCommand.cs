using MediatR;

namespace Application.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Place { get; set; } = null!;
    }
}
