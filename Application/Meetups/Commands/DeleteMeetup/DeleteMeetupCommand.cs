using MediatR;

namespace Application.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
