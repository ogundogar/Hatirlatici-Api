using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Queries.UserImageFile.GetUserImage
{
    public class GetUserImageQueryHandler : IRequestHandler<GetUserImageQueryRequest, List<GetUserImageQueryResponse>>
    {
        readonly IReadUsersRepository _readUsersRepository;

        public GetUserImageQueryHandler(IReadUsersRepository readUsersRepository)
        {
            _readUsersRepository = readUsersRepository;
        }

        public async Task<List<GetUserImageQueryResponse>> Handle(GetUserImageQueryRequest request, CancellationToken cancellationToken)
        {
            TbUsers? users = await _readUsersRepository.Table.Include(p => p.UserImageFiles).FirstOrDefaultAsync(p => p.Id == request.id);
           
            return users?.UserImageFiles.Select(p => new GetUserImageQueryResponse
            {
                path = p.Path,
                fileName = p.FileName,
                id = p.Id
            }).ToList();

        }
    }
}
