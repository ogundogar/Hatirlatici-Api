using HatirlaticiAPI.Application.Repositories.UsersRepository;
using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IWriteUsersRepository _writeUsersRepository;

        public CreateUserCommandHandler(IWriteUsersRepository writeUsersRepository)
        {
            _writeUsersRepository = writeUsersRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeUsersRepository.AddAsync(new()
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                DateOfBrith = DateTime.Parse(request.DateOfBrith),
            });
            await _writeUsersRepository.SaveAsync();
            return new();
        }
    }
}
