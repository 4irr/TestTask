using Application.Meetups.Queries.GetMeetupsDetails;
using MediatR;

namespace Application.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQuery : IRequest<MeetupDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
