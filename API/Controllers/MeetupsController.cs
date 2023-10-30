using Application.Meetups.Commands.CreateMeetup;
using Application.Meetups.Commands.DeleteMeetup;
using Application.Meetups.Commands.UpdateMeetup;
using Application.Meetups.Queries.GetMeetupDetails;
using Application.Meetups.Queries.GetMeetupsList;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    public class MeetupsController : BaseController
    {
        private readonly IMapper _mapper;
        public MeetupsController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of meetups
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /meetups
        /// </remarks>
        /// <returns>Returns MeetupsListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetMeetups()
        {
            var query = new GetMeetupsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the meetup by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /meetups/CD9A1F31-936D-4DA9-B336-018BC0E9E9CB
        /// </remarks>
        /// <param name="id">Meetup id (guid)</param>
        /// <returns>Returns MeetupDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        /// <response code="404">If the meetup is not found</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetMeetup(Guid id)
        {
            var query = new GetMeetupDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates a new meetup
        /// </summary>
        /// <remarks>
        /// Sample reques:
        /// POST /meetups/create
        /// </remarks>
        /// <param name="dto">Meetup info</param>
        /// <returns>Meetup id</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If user is unauthorized</response>
        [HttpPost("create")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create(CreateMeetupDto dto)
        {
            var command = _mapper.Map<CreateMeetupCommand>(dto);
            Guid id = await Mediator.Send(command);
            return Ok(id);
        }

        /// <summary>
        /// Updates the meetup
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /meetups/70CA7666-C616-4044-9752-8DA25DE081E5/update
        /// </remarks>
        /// <param name="id">Meetup id</param>
        /// <param name="dto">UpdateMeetupDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        /// <response code="404">If the meetup is not found</response>
        [HttpPut("{id}/update")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateMeetupDto dto)
        {
            var command = _mapper.Map<UpdateMeetupCommand>(dto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Removes the meetup by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /meetups/29DC1316-5459-46A9-8C74-8D370097B0FF/remove
        /// </remarks>
        /// <param name="id">Id of the meetup (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        /// <response code="404">If the meetup is not found</response>
        [HttpDelete("{id}/remove")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Remove(Guid id)
        {
            var command = new DeleteMeetupCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
