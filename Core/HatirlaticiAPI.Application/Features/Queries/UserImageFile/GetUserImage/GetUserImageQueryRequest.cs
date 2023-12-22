using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Queries.UserImageFile.GetUserImage
{
    public class GetUserImageQueryRequest:IRequest<List<GetUserImageQueryResponse>>
    {
        public int id { get; set; }
    }
}
