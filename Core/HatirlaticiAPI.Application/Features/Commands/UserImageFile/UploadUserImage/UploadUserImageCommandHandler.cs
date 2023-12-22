using HatirlaticiAPI.Application.Abstractions.Storage;
using HatirlaticiAPI.Application.Repositories.UserImageFileRepository;
using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Commands.UserImageFile.UploadUserImage
{
    public class UploadUserImageCommandHandler : IRequestHandler<UploadUserImageCommandRequest, UploadUserImageCommandResponse>
    {
        readonly IReadUsersRepository _readUsersRepository;
        readonly IWriteUserImageFileRepository _writeUserImageFileRepository;
        readonly IStorageService _storageService;

        public UploadUserImageCommandHandler(IReadUsersRepository readUsersRepository, IWriteUserImageFileRepository writeUserImageFileRepository, IStorageService storageService)
        {
            _readUsersRepository = readUsersRepository;
            _writeUserImageFileRepository = writeUserImageFileRepository;
            _storageService = storageService;
        }

        public async Task<UploadUserImageCommandResponse> Handle(UploadUserImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-image", request.Files);
            TbUsers tbUsers = await _readUsersRepository.GetByIdAsync(request.Id);

            await _writeUserImageFileRepository.AddRangeAsync(result.Select(r => new TbUserImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Users = new List<TbUsers>() { tbUsers }
            }).ToList());
            await _writeUserImageFileRepository.SaveAsync();
            return new();
        }
    }
}
