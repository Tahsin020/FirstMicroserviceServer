﻿using FirstMicroservice.Todos.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMicroservice.Todos.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}