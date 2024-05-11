namespace MLBooks.Infrastructure;

public record MongoDbSettings 
{
    public string ConnectionString { get; set; } = string.Empty!;
    public string DatabaseName { get; set; } = string.Empty!;
    public string BookCollection { get; set; } = string.Empty!;
}