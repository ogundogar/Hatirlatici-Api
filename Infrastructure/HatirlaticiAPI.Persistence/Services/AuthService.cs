using Google.Apis.Auth;
using HatirlaticiAPI.Application.Abstractions.Services;
using HatirlaticiAPI.Application.Abstractions.Token;
using HatirlaticiAPI.Application.DTOs;
using HatirlaticiAPI.Application.Exceptions;
using HatirlaticiAPI.Application.Features.Commands.AppUser.LoginUser;
using HatirlaticiAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HatirlaticiAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly IAppUserService _appUserService;
        public AuthService(UserManager<Domain.Entities.Identity.AppUser> userManager,
            ITokenHandler tokenHandler,
            IConfiguration configuration,
            SignInManager<Domain.Entities.Identity.AppUser> signInManager,
            IAppUserService appUserService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _appUserService= appUserService;
        }
       
        async Task<TokenDTO> CreateUserExternalAsync(AppUser appUser, string email,string name,UserLoginInfo info,int accessTokenLifeTime)
        {
            bool result = appUser != null;
            if (appUser == null)
            {
                appUser = await _userManager.FindByEmailAsync(email);
                if (appUser == null)
                {
                    appUser = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = name.Replace(" ", ""),
                    };
                    var identityResult = await _userManager.CreateAsync(appUser);
                    result = identityResult.Succeeded;
                }
            }
            if (result)
            {
                await _userManager.AddLoginAsync(appUser, info);
                TokenDTO token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                await _appUserService.UpdateRefreshToken(token.RefreshToken, appUser, token.Expiration, 20);
                return token;
            }
            else
            throw new Exception("Başarısız kayıt işlemi...");
            
           
      
        }
        public async Task<TokenDTO> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["ExternalLoginSettings:GoogleLogin:idToken"] }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            return await CreateUserExternalAsync(user, payload.Email,payload.Name,info, accessTokenLifeTime);
        }
        public async Task<TokenDTO> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime)
        {
            Domain.Entities.Identity.AppUser appUser = await _userManager.FindByNameAsync(userNameOrEmail);
            if (appUser == null)
                appUser = await _userManager.FindByEmailAsync(userNameOrEmail);
            if (appUser == null)
                throw new NotFoundUserException("Kullanıcı ad veya şifre hatalı...");
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, password, false);
            if (result.Succeeded)
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                await _appUserService.UpdateRefreshToken(token.RefreshToken, appUser, token.Expiration, 20);
                return token;
            }
            throw new Exception("Başarısız kayıt işlemi...");
        }

        public async Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(15);
                await _appUserService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 100);
                return token;
            }
            else
            throw new NotFoundUserException();
        }
    }
}
