using HatirlaticiAPI.Domain.Entities;
using HatirlaticiAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Persistence.Contexts
{
    public class HatirlaticiDbContext:DbContext
    {
       public HatirlaticiDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<TbUsers>? Users { get; set; }
        public DbSet<TbGroups>? Groups { get; set; }
        public DbSet<TbReminder>? Reminders { get; set; }
        public DbSet<TbFile>? TbFiles { get; set; }
        public DbSet<TbUserImageFile>? UserImageFiles { get; set; }
        public DbSet<TbGroupImageFile>? GroupImageFiles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas) {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreateDate =DateTime.UtcNow,
                    EntityState.Modified=>item.Entity.UpdateDate= DateTime.UtcNow,
                    _=>DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
