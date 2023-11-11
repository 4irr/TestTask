using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandHandler : IRequestHandler<UpdateMeetupCommand>
    {
        private readonly IRepository<Meetup> _repository;
        private readonly IMapper _mapper;

        public UpdateMeetupCommandHandler(IRepository<Meetup> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindByIdAsync(request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Speaker = request.Speaker;
            entity.DateTime = request.DateTime;
            entity.Place = request.Place;

            _repository.Update(entity);
        }
    }
}
