using HatirlaticiAPI.Application.Abstractions.Services;
using HatirlaticiAPI.Application.DTOs.AppUser;
using HatirlaticiAPI.Application.Exceptions;
using HatirlaticiAPI.Application.Features.Commands.AppUser.CreateAppUser;
using HatirlaticiAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Persistence.Services
{
    public class AppUserService : IAppUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateAppUserResponseDTO> CreateAsync(CreateAppUserRequestDTO model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.userName,
                Email = model.email,

            }, model.password);

            CreateAppUserResponseDTO response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarılı bir şekilde kaydedildi.";
            }
            else
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            return response;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate =  accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            throw new NotFoundUserException();
        }
    }
}
