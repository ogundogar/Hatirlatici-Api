using HatirlaticiAPI.Application.Features.Commands.AppUser.CreateAppUser;
using HatirlaticiAPI.Application.Features.Commands.AppUser.GoogleLogin;
using HatirlaticiAPI.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HatirlaticiAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : Controller
    {
        readonly private IMediator _mediator;
        public AppUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserCommandRequest request)
        {
            CreateAppUserCommandResponse response= await _mediator.Send(request);
            return Ok(response);
        }
       
    }
}
