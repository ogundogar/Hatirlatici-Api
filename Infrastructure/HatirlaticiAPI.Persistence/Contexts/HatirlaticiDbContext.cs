using HatirlaticiAPI.Domain.Entities;
using HatirlaticiAPI.Domain.Entities.Common;
using HatirlaticiAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HatirlaticiAPI.Persistence.Contexts
{
    public class HatirlaticiDbContext : IdentityDbContext<AppUser,AppRole,string>
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
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
