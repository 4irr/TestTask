using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;

namespace Application.Meetups.Queries.GetMeetupsList
{
    public class GetMeetupsListQueryHandler : IRequestHandler<GetMeetupsListQuery, MeetupsListVm>
    {
        private readonly IRepository<Meetup> _repository;
        private readonly IMapper _mapper;

        public GetMeetupsListQueryHandler(IRepository<Meetup> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<MeetupsListVm> Handle(GetMeetupsListQuery request, CancellationToken cancellationToken)
        {
            var meetups = await _repository.GetAsync(cancellationToken);

            var meetupsQuery = meetups.AsQueryable()
                .ProjectTo<MeetupLookupDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new MeetupsListVm { Meetups = meetupsQuery };
        }
    }
}
