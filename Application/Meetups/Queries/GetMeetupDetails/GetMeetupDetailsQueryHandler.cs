using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Meetups.Queries.GetMeetupsDetails;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQueryHandler : IRequestHandler<GetMeetupDetailsQuery, MeetupDetailsVm>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetMeetupDetailsQueryHandler(IApplicationContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<MeetupDetailsVm> Handle(GetMeetupDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Meetups.FirstOrDefaultAsync(meetup => meetup.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            return _mapper.Map<MeetupDetailsVm>(entity);
        }
    }
}
