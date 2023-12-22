using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Queries.Users.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public int TotalCount { get; set; }
        public object Users { get; set; }
    }
}
