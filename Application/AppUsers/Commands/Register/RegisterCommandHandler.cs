using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.AppUsers.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(UserManager<AppUser> userManager, IMapper mapper) => 
            (_userManager, _mapper) = (userManager, mapper);

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password!);

            if(!result.Succeeded)
            {
                throw new Exception("Failed to register user");
            }

            return user.Id;
        }
    }
}
