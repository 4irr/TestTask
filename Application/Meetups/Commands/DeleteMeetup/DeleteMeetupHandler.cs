using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupHandler : IRequestHandler<DeleteMeetupCommand>
    {
        private readonly IRepository<Meetup> _repository;

        public DeleteMeetupHandler(IRepository<Meetup> repository) => _repository = repository;

        public async Task Handle(DeleteMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            _repository.Remove(entity);
        }
    }
}
