using HatirlaticiAPI.Application.DTOs.AppUser;
using HatirlaticiAPI.Application.Features.Commands.AppUser.CreateAppUser;
using HatirlaticiAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Abstractions.Services
{
    public interface IAppUserService
    {
        Task<CreateAppUserResponseDTO> CreateAsync(CreateAppUserRequestDTO model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate,int addOnAccessTokenDate);
    }
}
