using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;
using TaskWebApp.Models;

namespace TaskWebApp.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Zadaca> tasks { get; set; }
        
    }
}
