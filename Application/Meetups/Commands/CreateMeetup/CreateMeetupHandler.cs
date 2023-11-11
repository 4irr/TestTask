using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupHandler : IRequestHandler<CreateMeetupCommand, Guid>
    {
        private readonly IRepository<Meetup> _repository;
        private readonly IMapper _mapper;

        public CreateMeetupHandler(IRepository<Meetup> repository, IMapper mapper) 
            => (_repository, _mapper) = (repository, mapper);

        public async Task<Guid> Handle(CreateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = _mapper.Map<Meetup>(request);

            var entity = await _repository.CreateAsync(meetup, cancellationToken);

            return entity.Id;
        }
    }
}
