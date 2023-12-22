using HatirlaticiAPI.Application.Abstractions.Services.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Abstractions.Services
{
    public interface IAuthService:IExternalAuthentications,IInternalAuthentication
    {
        
    }
}
