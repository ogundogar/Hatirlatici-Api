using HatirlaticiAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HatirlaticiDbContext>
    {
        public HatirlaticiDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<HatirlaticiDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
