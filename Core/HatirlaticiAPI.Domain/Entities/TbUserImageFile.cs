using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Domain.Entities
{
    public class TbUserImageFile:TbFile
    {
        public ICollection<TbUsers> Users { get; set; }
    }
}
