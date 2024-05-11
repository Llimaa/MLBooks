using MLBooks.Application;
using MLBooks.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddServices 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IDbContext, DbContext>();
        return services;
    }
}
