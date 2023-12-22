using HatirlaticiAPI.Application.Features.Commands.UserImageFile.DeleteUserImage;
using HatirlaticiAPI.Application.Features.Commands.UserImageFile.UploadUserImage;
using HatirlaticiAPI.Application.Features.Commands.Users.CreateUser;
using HatirlaticiAPI.Application.Features.Commands.Users.DeleteUser;
using HatirlaticiAPI.Application.Features.Commands.Users.UpdateUser;
using HatirlaticiAPI.Application.Features.Queries.UserImageFile.GetUserImage;
using HatirlaticiAPI.Application.Features.Queries.Users.GetAllUser;
using HatirlaticiAPI.Application.Features.Queries.Users.GetByIdAsyncUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HatirlaticiAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes="Admin")]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllUserQueryRequest getAllUserQueryRequest)
        {
            GetAllUserQueryResponse response = await _mediator.Send(getAllUserQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdUserQueryRequest request)
        {
            GetByIdUserQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommandRequest request)
        {
            UpdateUserCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommandRequest request)
        {
            DeleteUserCommandResponse response = await _mediator.Send(request);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadUserImageCommandRequest request)
        {
            request.Files = Request.Form.Files;
            UploadUserImageCommandResponse response = await _mediator.Send(request);
            return Ok();
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserImage([FromRoute] GetUserImageQueryRequest request)
        {
            List<GetUserImageQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]/{userId}")]
        public async Task<IActionResult> DeleteUserImage([FromRoute] DeleteUserImageCommandRequest request, [FromQuery] int imageId)
        {
            request.imageId = imageId;
            DeleteUserImageCommandResponse response = await _mediator.Send(request);
            return Ok();
        }
    }
}
