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
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppUserDto>> LoginAsync(LoginDto loginDto)
        {
            var query = _mapper.Map<LoginQuery>(loginDto);
            return await Mediator.Send(query);
        }
    }
}
