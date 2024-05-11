namespace MLBooks.Application;

public interface IBookService 
{
    Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken);
    Task<Guid> AddAsync(BookRequest request, CancellationToken cancellationToken);
    Task EditAsync(Guid id, BookRequest request, CancellationToken  cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
