using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

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

app.MapGet("/api/books", () =>
{
    return Results.Ok(BookStore.bookList);
});

app.MapGet("/api/books/{id:int}",(int id) =>
{
    return Results.Ok(BookStore.bookList.FirstOrDefault(u => u.Id == id));
});

app.MapPost("/api/books", ([FromBody] Book book) =>
{
    if (book.Id == 0||book.Id > BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id)
    {
        book.Id = BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    }
    
    BookStore.bookList.Add(book);
    return Results.Ok(book);
});



app.UseHttpsRedirection();


app.Run();


