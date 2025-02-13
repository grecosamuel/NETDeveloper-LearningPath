using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(app => {
    app.SwaggerDoc("v1", new OpenApiInfo { Title = "Books Minimal API v1", Description = "Minimal Web API Project for books demo project.", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(ui => {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksMinimalApi v1");
    });
}

app.MapGet("/", () => "Hello World!");

app.Run();
