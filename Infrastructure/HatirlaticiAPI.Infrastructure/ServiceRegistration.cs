using HatirlaticiAPI.Application.Abstractions.Storage;
using HatirlaticiAPI.Application.Abstractions.Token;
using HatirlaticiAPI.Infrastructure.Services.Storage;
using HatirlaticiAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;


namespace HatirlaticiAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
