

using FluentValidation;
using MLBooks.Application;

namespace MLBooks.Api;

public class ValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<BookRequest>>();

        if(validator is not null)
        {
            var entity = context.Arguments
                .OfType<BookRequest>()
                .FirstOrDefault(x => x?.GetType() == typeof(BookRequest));

            if(entity is not null)
            {
                var results = await validator.ValidateAsync(entity);

                if(!results.IsValid)
                {
                    return Results.ValidationProblem(results.ToDictionary());
                }
            }else {
                return Results.Problem("Error Not Found");
            }
        }
        return await next(context);
    }
}
