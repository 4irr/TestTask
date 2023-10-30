using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupHandler : IRequestHandler<DeleteMeetupCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteMeetupHandler(IApplicationContext context) => _context = context;
        public async Task Handle(DeleteMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Meetups.FindAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            _context.Meetups.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
