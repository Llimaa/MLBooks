using MongoDB.Driver;

namespace MLBooks.Infrastructure;

public interface IDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}
