using FirstMicroservice.Categories.Context;
using FirstMicroservice.Categories.Dto;
using FirstMicroservice.Categories.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

var app = builder.Build();

app.MapGet("/categories/getall", async (ApplicationDbContext context, CancellationToken cancellationToken) =>
{
    var data = await context.Categories.ToListAsync(cancellationToken);
    return data;
});

app.MapPost("/categories/create", async (CreateCategoryDto request, ApplicationDbContext context, CancellationToken cancellationToken) =>
{
    bool isNameExist = await context.Categories.AnyAsync(p => p.Name == request.Name, cancellationToken);
    if (isNameExist)
    {
        return Results.BadRequest(new { Message = "Category already exists" });
    }
    Category category = new()
    {
        Name = request.Name
    };
    await context.AddAsync(category, cancellationToken);
    await context.SaveChangesAsync(cancellationToken);
    return Results.Ok(new { Message = "Category create is successful" });
});


app.Run();
