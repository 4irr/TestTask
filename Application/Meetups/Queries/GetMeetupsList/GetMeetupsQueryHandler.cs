using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Meetups.Queries.GetMeetupsList
{
    public class GetMeetupsListQueryHandler : IRequestHandler<GetMeetupsListQuery, MeetupsListVm>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetMeetupsListQueryHandler(IApplicationContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<MeetupsListVm> Handle(GetMeetupsListQuery request, CancellationToken cancellationToken)
        {
            var meetupsQuery = await _context.Meetups
                .ProjectTo<MeetupLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MeetupsListVm { Meetups = meetupsQuery };
        }
    }
}
