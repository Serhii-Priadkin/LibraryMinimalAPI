using AutoMapper;
using Library;
using Library.Data;
using Library.Models;
using Library.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

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

app.MapGet("/api/books{title_or_author}", (ILogger<Program> _logger,string title_or_author) =>
{
    _logger.Log(LogLevel.Information, $"Ordering all Books by {title_or_author}");
    var res = from b in BookStore.bookList
              join rat in RatingStore.ratingList on b.Id equals rat.BookId into rati
              join rev in ReviewStore.reviewList on b.Id equals rev.BookId into revi
              orderby (title_or_author == "title"|| title_or_author == "Title"?b.Title:b.Author)
              select new
              {
                  b.Id,
                  b.Title,
                  b.Author,
                  b.Cover,
                  b.Content,
                  rating = rati.Average(s => s.Score),
                  reviews = revi.Count()
              };
    return Results.Ok(res);
}).Produces<IEnumerable<Book>>(200);

app.MapGet("/api/books/{id:int}", (ILogger<Program> _logger, int id) =>
{
    _logger.Log(LogLevel.Information, "Getting book details!");
    var res = from b in BookStore.bookList
              join rat in RatingStore.ratingList on b.Id equals rat.BookId into rati
              join rev in ReviewStore.reviewList on b.Id equals rev.BookId into revi

              select new
              {
                  b.Id,
                  b.Title,
                  b.Author,
                  b.Cover,
                  b.Content,
                  rating = rati.Average(s => s.Score),
                  reviews = from r in revi
                            select new
                            {
                                r.Id,
                                r.Message,
                                r.Reviewer
                            }
              };

    return Results.Ok(res.FirstOrDefault(u => u.Id == id));
}).Produces<Book>(200);

app.MapGet("/api/horror", (ILogger<Program> _logger) =>
{
    _logger.Log(LogLevel.Information, "Getting all Books");
    var res = from b in BookStore.bookList where b.Genre=="Horror"
              join rat in RatingStore.ratingList on b.Id equals rat.BookId into rati
              join rev in ReviewStore.reviewList on b.Id equals rev.BookId into revi
              where revi.Count()>10
              orderby rati.Average(s => s.Score) descending
              select new
              {
                  b.Id,
                  b.Title,
                  b.Author,
                  rating = rati.Average(s => s.Score),
                  reviews = revi.Count()
              }
              ;
    return Results.Ok(res.Take(10));
}).Produces<IEnumerable<Book>>(200);

app.MapPost("/api/books", (IMapper _mapper, [FromBody] BookCreateDTO book_C_DTO) =>
{
    if (book_C_DTO.Id == 0 || book_C_DTO.Id > BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id)
    {
        book_C_DTO.Id = BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    }

    Book book = _mapper.Map<Book>(book_C_DTO);

    BookStore.bookList.Add(book);
    return Results.Ok(book.Id);
}).Produces<Book>(201);



app.UseHttpsRedirection();


app.Run();


