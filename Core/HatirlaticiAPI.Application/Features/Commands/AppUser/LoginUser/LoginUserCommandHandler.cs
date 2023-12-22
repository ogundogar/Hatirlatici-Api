using HatirlaticiAPI.Application.Abstractions.Services;
using HatirlaticiAPI.Application.DTOs;
using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDTO token = await _authService.LoginAsync(request.userNameOrEmail, request.password,10);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
