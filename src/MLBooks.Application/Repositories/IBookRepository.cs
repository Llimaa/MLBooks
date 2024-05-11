namespace MLBooks.Application;

public interface IBookRepository 
{
    Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Book book, CancellationToken cancellationToken);
    Task EditAsync(Book book, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
