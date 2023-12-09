using HatirlaticiAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Persistence.Repositories.UsersRepository;
using HatirlaticiAPI.Persistence.Repositories.GroupsRepository;
using HatirlaticiAPI.Application.Repositories.GroupsRepository;
using HatirlaticiAPI.Application.Repositories.ReminderRepository;
using HatirlaticiAPI.Persistence.Repositories.ReminderRepository;
using HatirlaticiAPI.Application.Repositories.GroupImageFileRepository;
using HatirlaticiAPI.Persistence.Repositories.GroupImageFileRepository;
using HatirlaticiAPI.Application.Repositories.UserImageFileRepository;
using HatirlaticiAPI.Persistence.Repositories.UserImageFileRepository;

namespace HatirlaticiAPI.Persistence
{
    public static class ServiceRegistration
    {
        
        public static void AddPersistenceServices(this IServiceCollection services)
        {        
            services.AddDbContext<HatirlaticiDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<IReadUsersRepository, ReadUsersRepository>();
            services.AddScoped<IWriteUsersRepository, WriteUsersRepository>();
            services.AddScoped<IReadGroupsRepository, ReadGroupsRepository>();
            services.AddScoped<IWriteGroupsRepository, WriteGroupsRepository>();
            services.AddScoped<IReadReminderRepository, ReadReminderRepository>();
            services.AddScoped<IWriteReminderRepository, WriteReminderRepository>();
            services.AddScoped<IReadGroupImageFileRepository, ReadGroupImageFileRepository>();
            services.AddScoped<IWriteGroupImageFileRepository, WriteGroupImageFileRepository>();
            services.AddScoped<IReadUserImageFileRepository, ReadUserImageFileRepository>();
            services.AddScoped<IWriteUserImageFileRepository, WriteUserImageFileRepository>();
        }
    }
}
