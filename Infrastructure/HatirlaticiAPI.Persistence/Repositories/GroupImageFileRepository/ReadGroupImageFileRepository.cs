using HatirlaticiAPI.Application.Repositories.GroupImageFileRepository;
using HatirlaticiAPI.Domain.Entities;
using HatirlaticiAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Persistence.Repositories.GroupImageFileRepository
{
    public class ReadGroupImageFileRepository : ReadRepository<TbGroupImageFile>, IReadGroupImageFileRepository
    {
        public ReadGroupImageFileRepository(HatirlaticiDbContext context) : base(context)
        {
        }
    }
}
