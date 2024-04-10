using CleanArchitectureMaui.Persistence.Data;
using CleanArchitectureMaui.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureMaui.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services) 
        {
            return services.AddSingleton<IUnitOfWork, AppUnitOfWork>();
        }

        public static IServiceCollection AddPersistence(
            this IServiceCollection services, DbContextOptions options)
        {
            return services
                .AddPersistence()
                .AddSingleton(
                    new AppDbContext(
                        (DbContextOptions<AppDbContext>)options));
        }
    }
}
