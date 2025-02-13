using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BooksMinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookDb>(options => options.UseInMemoryDatabase("books-database"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(app =>
{
    app.SwaggerDoc("v1", new OpenApiInfo { Title = "Books Minimal API v1", Description = "Minimal Web API Project for books demo project.", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksMinimalApi v1");
    });
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapGet("/books", async (BookDb db) => await db.Books.ToListAsync());

app.MapPost("/books/add", async (BookDb db, Book book) =>
{
    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapGet("/books/{id}", async (BookDb db, int id) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();
    return Results.Ok(book);
});

app.MapPut("/books/update/{id}", async (BookDb db, Book updateBook, int id) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();
    book.Title = updateBook.Title;
    book.Author = updateBook.Author;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/books/delete/{id}", async (BookDb db, int id) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();
    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
