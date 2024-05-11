
namespace MLBooks.Application;

public class BookService(IBookRepository repository) : IBookService
{
    private readonly IBookRepository repository = repository;

    public async Task<Guid> AddAsync(BookRequest request, CancellationToken cancellationToken)
    {
        var book = new Book(request.Title, request.Description, request.Status);

        await repository.AddAsync(book, cancellationToken);
        return book.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken) =>
        await repository.DeleteAsync(id, cancellationToken);

    public async Task EditAsync(Guid id, BookRequest request, CancellationToken cancellationToken)
    {
        var bookResult = await repository.GetByIdAsync(id, cancellationToken);

        bookResult.Update(request.Title, request.Description, request.Status);
        await repository.EditAsync(bookResult, cancellationToken);
    }

    async Task<IEnumerable<Book>> IBookService.GetAllAsync(CancellationToken cancellationToken) =>
        await repository.GetAllAsync(cancellationToken);
}
