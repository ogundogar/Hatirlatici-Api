using HatirlaticiAPI.Application.Abstractions.Services;
using HatirlaticiAPI.Application.DTOs;
using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDTO response = await _authService.GoogleLoginAsync(request.idToken,10);
            return new()
            {
                Token = response
            };
        }
    }
}
