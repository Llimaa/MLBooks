using Microsoft.OpenApi.Models;
using MLBooks.Api;
using MLBooks.Application;
using MLBooks.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "MLBooks- Api", Description = "Api responsável pelo gerenciamento de livros", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "MLBooks Api");
});

app.MapGet("books", async (IBookService services, CancellationToken cancellationToken) =>
    await services.GetAllAsync(cancellationToken));

app.MapPost("books", async (BookRequest request, IBookService services, CancellationToken cancellationToken) =>
    await services.AddAsync(request, cancellationToken)).AddEndpointFilter<ValidationFilter>();

app.MapPut("books/{id}", async (Guid id, BookRequest request, IBookService services, CancellationToken cancellationToken) =>
    await services.EditAsync(id, request, cancellationToken)).AddEndpointFilter<ValidationFilter>();

app.MapDelete("books{id}", async (Guid id, IBookService services, CancellationToken cancellationToken) =>
    await services.DeleteAsync(id, cancellationToken));

app.Run();
