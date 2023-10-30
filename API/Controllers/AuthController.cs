using Application.AppUsers.Queries.Login;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;
        public AuthController(IMapper mapper) => _mapper = mapper;

        [HttpPost("login")]
        public async Task<ActionResult<AppUserDto>> LoginAsync(LoginDto loginDto)
        {
            var query = _mapper.Map<LoginQuery>(loginDto);
            return await Mediator.Send(query);
        }
    }
}
