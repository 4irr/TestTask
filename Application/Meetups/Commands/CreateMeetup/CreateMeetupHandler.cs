using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupHandler : IRequestHandler<CreateMeetupCommand, Guid>
    {
        private readonly IApplicationContext _context;

        public CreateMeetupHandler(IApplicationContext context) => _context = context;

        public async Task<Guid> Handle(CreateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = new Meetup
            {
                Name = request.Name,
                Description = request.Description,
                Speaker = request.Speaker,
                DateTime = request.DateTime,
                Place = request.Place
            };

            await _context.Meetups.AddAsync(meetup);
            await _context.SaveChangesAsync(cancellationToken);

            return meetup.Id;
        }
    }
}
