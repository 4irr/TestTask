using Application.AppUsers.Commands.Register;
using Application.AppUsers.Queries.Login;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("/api/auth")]
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper, IMediator mediator) : base(mediator) => _mapper = mapper;

        /// <summary>
        /// Provides authentication for user
        /// </summary>
        /// <remarks>
        /// Sample reques:
        /// POST /login
        /// </remarks>
        /// <param name="loginDto">
        /// Login and password (There are two test users: Login: user1, Password: password; Login: user2, Password: password)
        /// </param>
        /// <returns>Returns authenticated user with access token</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If login or password wrong</response>
        /// <response code="400">Validation error</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppUserDto>> LoginAsync(LoginDto loginDto)
        {
            var query = _mapper.Map<LoginQuery>(loginDto);
            var dto = await _mediator.Send(query);

            return Ok(dto);
        }

        /// <summary>
        /// Provides registration for user
        /// </summary>
        /// <remarks>
        /// Sample reques:
        /// POST /register
        /// </remarks>
        /// <param name="registerDto">
        /// RegisterDto object
        /// </param>
        /// <returns>Returns user id</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Validation error</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> RegisterAsync(RegisterDto registerDto)
        {
            var command = _mapper.Map<RegisterCommand>(registerDto);
            var userId = await _mediator.Send(command);

            return Ok(userId);
        }
    }
}
