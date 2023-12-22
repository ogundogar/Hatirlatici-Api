using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Application.RequestParameters;
using HatirlaticiAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Queries.Users.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        readonly IReadUsersRepository _readUsersRepository;
        public GetAllUserQueryHandler(IReadUsersRepository readUsersRepository)
        {
            _readUsersRepository = readUsersRepository;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _readUsersRepository.GetAll(false).Count();
            var users = _readUsersRepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.UserName,
                p.Email,
                p.Password,
                p.DateOfBrith,
                p.CreateDate,
                p.UpdateDate
            }).OrderByDescending(p => p.Id).Skip(request.Page * request.Size).Take(request.Size);
            var response = new GetAllUserQueryResponse
            {
                TotalCount = totalCount,
                Users = users
            };
            return await Task.FromResult(response);

        }
    }
}

