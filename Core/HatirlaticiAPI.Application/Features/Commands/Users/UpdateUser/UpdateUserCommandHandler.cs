using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Domain.Entities;
using MediatR;

namespace HatirlaticiAPI.Application.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        readonly IReadUsersRepository _readUsersRepository;
        readonly IWriteUsersRepository _writeUsersRepository;

        public UpdateUserCommandHandler(IReadUsersRepository readUsersRepository, IWriteUsersRepository writeUsersRepository)
        {
            _readUsersRepository = readUsersRepository;
            _writeUsersRepository = writeUsersRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            TbUsers user = await _readUsersRepository.GetByIdAsync(request.Id);
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.DateOfBrith = request.DateOfBrith;
            await _writeUsersRepository.SaveAsync();
            return new();
        }
    }
}
