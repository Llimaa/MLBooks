using FluentValidation;
using MLBooks.Application;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddServices 
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IValidator<BookRequest>, BookRequestValidator>();
        return services;
    }
}