﻿using HatirlaticiAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Domain.Entities
{
    public class TbFile:BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }

        public string Storage { get; set; }
        [NotMapped]
        public override DateTime UpdateDate { get=>base.UpdateDate; set=>base.UpdateDate = value;}
    }
}
