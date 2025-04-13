using Microsoft.EntityFrameworkCore;
using MiniwarenwirtschaftDemoAPI.Model;
using System.Collections.Generic;

namespace MiniwarenwirtschaftDemoAPI.Data
{
    // --- AppDbContext ---

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
