using HatirlaticiAPI.Application.Repositories.UsersRepository;
using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        readonly IWriteUsersRepository _writeUsersRepository;

        public DeleteUserCommandHandler(IWriteUsersRepository writeUsersRepository)
        {
            _writeUsersRepository = writeUsersRepository;
        }

        async Task<DeleteUserCommandResponse> IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>.Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeUsersRepository.RemoveAsync(request.Id);
            await _writeUsersRepository.SaveAsync();
            return new();
        }
    }
}
