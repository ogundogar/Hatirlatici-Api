using HatirlaticiAPI.Application.Repositories.UserImageFileRepository;
using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HatirlaticiAPI.Application.Features.Commands.UserImageFile.DeleteUserImage
{
    public class DeleteUserImageCommandHandler : IRequestHandler<DeleteUserImageCommandRequest, DeleteUserImageCommandResponse>
    {
        readonly IReadUsersRepository _readUsersRepository;
        readonly IWriteUsersRepository _writeUsersRepository;

        public DeleteUserImageCommandHandler(IReadUserImageFileRepository readUserImageFileRepository, IWriteUsersRepository writeUsersRepository, IReadUsersRepository readUsersRepository)
        {

            _writeUsersRepository = writeUsersRepository;
            _readUsersRepository = readUsersRepository;
        }

        public async Task<DeleteUserImageCommandResponse> Handle(DeleteUserImageCommandRequest request, CancellationToken cancellationToken)
        {
            TbUsers? users = await _readUsersRepository.Table.Include(p => p.UserImageFiles).FirstOrDefaultAsync(p => p.Id == request.userId);
            TbUserImageFile? userImageFile = users.UserImageFiles?.FirstOrDefault(p => p.Id == request.imageId);
           if(userImageFile!=null)
            users.UserImageFiles?.Remove(userImageFile);
            await _writeUsersRepository.SaveAsync();
            return new();
        }
    }
}
