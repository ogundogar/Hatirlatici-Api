﻿using HatirlaticiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Application.Repositories.ReminderRepository
{
    public interface IWriteReminderRepository:IWriteRepository<TbReminder>
    {
    }
}