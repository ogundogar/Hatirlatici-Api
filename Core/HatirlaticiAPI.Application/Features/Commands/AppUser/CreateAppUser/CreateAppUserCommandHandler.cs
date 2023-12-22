using HatirlaticiAPI.Application.Abstractions.Services;
using HatirlaticiAPI.Application.DTOs.AppUser;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HatirlaticiAPI.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        readonly IAppUserService _appUserService;

        public CreateAppUserCommandHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        { 

            CreateAppUserResponseDTO response =await _appUserService.CreateAsync(new()
            {
                email=request.email,
                password=request.password,
                userName=request.userName,
                birthday=request.birthday,
                confirmPassword=request.confirmPassword,
            });
            return new()
            {
                Message=response.Message,
                Succeeded=response.Succeeded,
            };
        }
    }
}
