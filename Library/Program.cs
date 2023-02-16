using Library.Data;
using Library.Models;
using Library.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/books", (ILogger<Program> _logger) =>
{
    _logger.Log(LogLevel.Information, "Getting all Books");
    return Results.Ok(BookStore.bookList);
});

app.MapGet("/api/books/{id:int}",(int id) =>
{
    return Results.Ok(BookStore.bookList.FirstOrDefault(u => u.Id == id));
});

app.MapPost("/api/books", ([FromBody] BookCreateDTO book_C_DTO) =>
{
    if (book_C_DTO.Id == 0|| book_C_DTO.Id > BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id)
    {
        book_C_DTO.Id = BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    }

    Book book = new()
    {
        Id = book_C_DTO.Id,
        Title = book_C_DTO.Title,
        Cover = book_C_DTO.Cover,
        Content = book_C_DTO.Content,
        Genre = book_C_DTO.Genre,
        Author = book_C_DTO.Author
    };

    BookStore.bookList.Add(book);
    return Results.Ok(book);
});



app.UseHttpsRedirection();


app.Run();


