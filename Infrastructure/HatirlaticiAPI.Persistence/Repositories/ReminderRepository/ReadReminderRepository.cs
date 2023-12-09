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
    public class ReadReminderRepository : ReadRepository<TbReminder>, IReadReminderRepository
    {
        public ReadReminderRepository(HatirlaticiDbContext context) : base(context)
        {
        }
    }
}
