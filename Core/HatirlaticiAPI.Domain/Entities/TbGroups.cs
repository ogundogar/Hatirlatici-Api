using HatirlaticiAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Domain.Entities
{
    public class TbGroups:BaseEntity
    {
        public string GroupName { get; set; }
        public ICollection<TbReminder>? Reminder { get; set; }
        public ICollection<TbGroupImageFile>? GroupImageFile { get; set; }
    }
}
