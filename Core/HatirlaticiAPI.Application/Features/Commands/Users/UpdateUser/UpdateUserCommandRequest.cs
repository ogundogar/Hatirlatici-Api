using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBrith { get; set; }
    }
}
