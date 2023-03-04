using Microsoft.EntityFrameworkCore;
using MyHrProject.Models;

namespace MyHrProject.Data;

public class MyHrProjectContext : DbContext
{
    public MyHrProjectContext(DbContextOptions<MyHrProjectContext> options)
        : base(options)
    {
    }

    public DbSet<Staff> Staff { get; set; } = default!;
}