using HatirlaticiAPI.Application.Abstractions.Services;
using HatirlaticiAPI.Application.Abstractions.Services.Authentications;
using HatirlaticiAPI.Application.Repositories.GroupImageFileRepository;
using HatirlaticiAPI.Application.Repositories.GroupsRepository;
using HatirlaticiAPI.Application.Repositories.ReminderRepository;
using HatirlaticiAPI.Application.Repositories.UserImageFileRepository;
using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Domain.Entities.Identity;
using HatirlaticiAPI.Persistence.Contexts;
using HatirlaticiAPI.Persistence.Repositories.GroupImageFileRepository;
using HatirlaticiAPI.Persistence.Repositories.GroupsRepository;
using HatirlaticiAPI.Persistence.Repositories.ReminderRepository;
using HatirlaticiAPI.Persistence.Repositories.UserImageFileRepository;
using HatirlaticiAPI.Persistence.Repositories.UsersRepository;
using HatirlaticiAPI.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HatirlaticiAPI.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<HatirlaticiDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric= false;
                options.Password.RequireDigit= false;
                options.Password.RequireLowercase= false;
                options.Password.RequireUppercase= false;
            }).AddEntityFrameworkStores<HatirlaticiDbContext>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentications, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
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
