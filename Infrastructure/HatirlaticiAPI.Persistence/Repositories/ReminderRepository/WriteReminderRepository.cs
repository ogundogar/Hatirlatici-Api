using HatirlaticiAPI.Application.Repositories.ReminderRepository;
using HatirlaticiAPI.Domain.Entities;
using HatirlaticiAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Persistence.Repositories.ReminderRepository
{
    public class WriteReminderRepository : WriteRepository<TbReminder>, IWriteReminderRepository
    {
        public WriteReminderRepository(HatirlaticiDbContext context) : base(context)
        {
        }
    }
}
