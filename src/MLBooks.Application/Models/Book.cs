namespace MLBooks.Application;

public class Book(string title, string description, Status status)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public Status Status { get; private set; } = status;

    public void Update(string title, string description, Status status) 
    {
        Title = title;
        Description = description;
        Status = status;
    }
}
