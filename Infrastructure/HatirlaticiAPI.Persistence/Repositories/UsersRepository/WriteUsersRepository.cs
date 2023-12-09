using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Domain.Entities;
using HatirlaticiAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Persistence.Repositories.UsersRepository
{
    public class WriteUsersRepository : WriteRepository<TbUsers>, IWriteUsersRepository
    {
        public WriteUsersRepository(HatirlaticiDbContext context) : base(context)
        {
        }
    }
}
