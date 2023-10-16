using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Accounts.Models;

namespace Todo.DataAccess.Context;

public class TodoDbContext : IdentityDbContext
{
    public TodoDbContext() {}
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {}

    public DbSet<Account> Accounts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var context = Assembly.GetAssembly(typeof(TodoDbContext));
        if (context is null) 
            throw new NullReferenceException();
        modelBuilder.ApplyConfigurationsFromAssembly(context);
    }
}