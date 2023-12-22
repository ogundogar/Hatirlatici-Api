using HatirlaticiAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Domain.Entities
{
    public class TbUsers:BaseEntity
    {
        public string UserName { get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public ICollection<TbReminder>? Reminders { get; set; }
        public ICollection<TbUserImageFile>? UserImageFiles { get; set; }
    }
}
