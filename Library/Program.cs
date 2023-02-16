using AutoMapper;
using Library;
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
builder.Services.AddAutoMapper(typeof(MappingConfig));
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
}).Produces<IEnumerable<Book>>(200);

app.MapGet("/api/books/{id:int}",(int id) =>
{
    return Results.Ok(BookStore.bookList.FirstOrDefault(u => u.Id == id));
}).Produces<Book>(200);

app.MapPost("/api/books", (IMapper _mapper, [FromBody] BookCreateDTO book_C_DTO) =>
{
    if (book_C_DTO.Id == 0|| book_C_DTO.Id > BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id)
    {
        book_C_DTO.Id = BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    }

    Book book = _mapper.Map<Book>(book_C_DTO);

    BookStore.bookList.Add(book);
    return Results.Ok(book.Id);
}).Produces<Book>(201);



app.UseHttpsRedirection();


app.Run();


