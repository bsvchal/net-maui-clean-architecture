using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureMaui.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            return services
                .AddMediatR(cnf =>
                    cnf.RegisterServicesFromAssembly(
                        typeof(DependencyInjection).Assembly));
        }
    }
}
