using FluentValidation;

namespace MLBooks.Application;

public class BookRequestValidator: AbstractValidator<BookRequest> 
{
    public BookRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title inválido");

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description inválido");

        RuleFor(x => x.Status)
            .NotNull()
            .WithMessage("Status inválido");   
    }
}
