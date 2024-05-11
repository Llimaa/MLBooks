using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MLBooks.Infrastructure;

public class DbContext : IDbContext
{
    private IMongoDatabase Database { get; }

    public DbContext(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        Database = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
    }
    public IMongoCollection<T> GetCollection<T>(string name) => Database.GetCollection<T>(name);
}