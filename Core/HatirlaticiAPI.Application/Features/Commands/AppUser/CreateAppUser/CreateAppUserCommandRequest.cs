using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateAppUserCommandRequest: IRequest<CreateAppUserCommandResponse>
    {
        public string userName { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}