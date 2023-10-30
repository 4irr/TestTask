using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandHandler : IRequestHandler<UpdateMeetupCommand>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public UpdateMeetupCommandHandler(IApplicationContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Meetups.FindAsync(request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Speaker = request.Speaker;
            entity.DateTime = request.DateTime;
            entity.Place = request.Place;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
