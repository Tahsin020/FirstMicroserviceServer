using FirstMicroservice.Todos.Context;
using FirstMicroservice.Todos.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("MyDb");
});

var app = builder.Build();

app.MapGet("/todos/create", async (string work, ApplicationDbContext context) =>
{
    Todo todo = new()
    {
        Work = work
    };
    await context.AddAsync(todo);
    await context.SaveChangesAsync();
    return new { Message = "Todo create is successful" };
});

app.MapGet("/todos/getall", (ApplicationDbContext context) =>
{
    var todos = context.Todos.ToList();
    return todos;
});

app.Run();
