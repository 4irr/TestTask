using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Meetups.Queries.GetMeetupsDetails;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQueryHandler : IRequestHandler<GetMeetupDetailsQuery, MeetupDetailsVm>
    {
        private readonly IRepository<Meetup> _repository;
        private readonly IMapper _mapper;

        public GetMeetupDetailsQueryHandler(IRepository<Meetup> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<MeetupDetailsVm> Handle(GetMeetupDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            return _mapper.Map<MeetupDetailsVm>(entity);
        }
    }
}
