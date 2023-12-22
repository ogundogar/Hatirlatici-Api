using HatirlaticiAPI.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Queries.Users.GetAllUser
{
    public class GetAllUserQueryRequest : IRequest<GetAllUserQueryResponse>
    {
        //public Pagination pagination { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
