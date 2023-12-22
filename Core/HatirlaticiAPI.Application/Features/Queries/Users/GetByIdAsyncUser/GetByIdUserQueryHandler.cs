using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Queries.Users.GetByIdAsyncUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        readonly IReadUsersRepository _readUsersRepository;

        public GetByIdUserQueryHandler(IReadUsersRepository readUsersRepository)
        {
            _readUsersRepository = readUsersRepository;
        }

        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
           TbUsers user= await _readUsersRepository.GetByIdAsync(request.Id, false);
            var response = new GetByIdUserQueryResponse()
            {
                UserName = user.UserName,
                Email = user.Email,
                DateOfBrith = user.DateOfBrith,
                Password = user.Password,
            };
            return await Task.FromResult(response);
        }
    }
}
