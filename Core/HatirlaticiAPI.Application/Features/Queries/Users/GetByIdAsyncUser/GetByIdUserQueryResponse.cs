using HatirlaticiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Features.Queries.Users.GetByIdAsyncUser
{
    public class GetByIdUserQueryResponse
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }

    }
}
