using HatirlaticiAPI.Application.Repositories.GroupsRepository;
using HatirlaticiAPI.Domain.Entities;
using HatirlaticiAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Persistence.Repositories.GroupsRepository
{
    public class ReadGroupsRepository : ReadRepository<TbGroups>, IReadGroupsRepository
    {
        public ReadGroupsRepository(HatirlaticiDbContext context) : base(context)
        {
        }
    }
}
