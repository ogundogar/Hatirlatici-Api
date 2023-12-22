using HatirlaticiAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentications
    {
        Task<TokenDTO> GoogleLoginAsync(string idToken,int accessTokenLifeTime);
    }
}
