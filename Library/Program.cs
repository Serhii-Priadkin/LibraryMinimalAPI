using AutoMapper;
using FluentValidation;
using Library;
using Library.Data;
using Library.Models;
using Library.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/books{title_or_author}", (ILogger<Program> _logger, string title_or_author) =>
{
    _logger.Log(LogLevel.Information, $"Ordering all Books by {title_or_author}");
    var res = from b in BookStore.bookList
              join rat in RatingStore.ratingList on b.Id equals rat.BookId into rati
              join rev in ReviewStore.reviewList on b.Id equals rev.BookId into revi
              orderby (title_or_author == "title" || title_or_author == "Title" ? b.Title : b.Author)
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
    var res = from b in BookStore.bookList
              where b.Genre == "Horror"
              join rat in RatingStore.ratingList on b.Id equals rat.BookId into rati
              join rev in ReviewStore.reviewList on b.Id equals rev.BookId into revi
              where revi.Count() > 10
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

app.MapPost("/api/books/save", (IMapper _mapper, [FromBody] BookCreateDTO book_C_DTO) =>
{
    if (book_C_DTO.Id == 0 || book_C_DTO.Id > BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id)
    {
        book_C_DTO.Id = BookStore.bookList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    }

    Book book = _mapper.Map<Book>(book_C_DTO);

    BookStore.bookList.Add(book);
    return Results.Ok(book.Id);
}).Produces<Book>(201);

app.MapPut("/api/books/{id:int}/review", (IMapper _mapper, int id, [FromBody] ReviewCreateDTO review_C_DTO) =>
{

    review_C_DTO.Id = ReviewStore.reviewList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    review_C_DTO.BookId = id;
    Review review = _mapper.Map<Review>(review_C_DTO);

    ReviewStore.reviewList.Add(review);
    return Results.Ok(review.Id);
}).Produces<Review>(201);

app.MapPut("/api/books/{id:int}/rate", (IMapper _mapper, [FromBody] RatingCreateDTO rating_C_DTO, IValidator<RatingCreateDTO> _validator,  int id) =>
{
    var validationResult = _validator.ValidateAsync(rating_C_DTO).GetAwaiter().GetResult();
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(validationResult.Errors.FirstOrDefault().ToString());
    }
    rating_C_DTO.Id = RatingStore.ratingList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    rating_C_DTO.BookId = id;
    Rating rating = _mapper.Map<Rating>(rating_C_DTO);

    RatingStore.ratingList.Add(rating);
    return Results.Ok(rating.Score);
}).Produces<Rating>(201).Produces(400);



app.UseHttpsRedirection();


app.Run();


