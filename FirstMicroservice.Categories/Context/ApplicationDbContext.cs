using FirstMicroservice.Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMicroservice.Categories.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
}
