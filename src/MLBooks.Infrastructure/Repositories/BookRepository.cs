using Microsoft.Extensions.Options;
using MLBooks.Application;
using MongoDB.Driver;

namespace MLBooks.Infrastructure;

public class BookRepository(IOptions<MongoDbSettings> mongoDbSettings, IDbContext dbContext) : IBookRepository
{
    private readonly IMongoCollection<Book> collection = 
        dbContext.GetCollection<Book>(mongoDbSettings.Value.BookCollection);
    
    public async Task AddAsync(Book book, CancellationToken cancellationToken) =>
        await collection.InsertOneAsync(book, cancellationToken: cancellationToken);

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken) =>
        await collection.DeleteOneAsync(x=> x.Id == id, cancellationToken);

    public async Task EditAsync(Book book, CancellationToken cancellationToken) =>
        await collection.ReplaceOneAsync(x=> x.Id == book.Id, book, cancellationToken: cancellationToken);

    public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken) =>
        await collection.Find(_ => true).ToListAsync(cancellationToken);

    public async Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
}
