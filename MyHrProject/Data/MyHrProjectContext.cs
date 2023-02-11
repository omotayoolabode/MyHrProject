using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyHrProject.Models;

namespace MyHrProject.Data
{
    public class MyHrProjectContext : DbContext
    {
        public MyHrProjectContext (DbContextOptions<MyHrProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Staff> Staff { get; set; } = default!;
    }
}
