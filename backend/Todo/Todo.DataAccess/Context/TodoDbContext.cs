using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Todo.DataAccess.Context;

public class TodoDbContext : IdentityDbContext
{
    public TodoDbContext() {}
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var context = Assembly.GetAssembly(typeof(TodoDbContext));
        if (context is null) 
            throw new NullReferenceException();
        modelBuilder.ApplyConfigurationsFromAssembly(context);
    }
}