using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? DateOfBrith { get; set; }
    }
}
