using HatirlaticiAPI.Application.Repositories.UserImageFileRepository;
using HatirlaticiAPI.Domain.Entities;
using HatirlaticiAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Persistence.Repositories.UserImageFileRepository
{
    public class WriteUserImageFileRepository : WriteRepository<TbUserImageFile>, IWriteUserImageFileRepository
    {
        public WriteUserImageFileRepository(HatirlaticiDbContext context) : base(context)
        {
        }
    }
}
