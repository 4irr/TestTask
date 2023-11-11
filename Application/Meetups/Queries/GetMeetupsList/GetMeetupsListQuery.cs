using MediatR;

namespace Application.Meetups.Queries.GetMeetupsList
{
    public class GetMeetupsListQuery : IRequest<MeetupsListVm> { }
}
