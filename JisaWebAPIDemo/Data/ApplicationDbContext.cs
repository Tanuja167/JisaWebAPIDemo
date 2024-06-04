using Microsoft.EntityFrameworkCore;
using JisaWebAPIDemo.Models;

namespace JisaWebAPIDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Book> Books { get; set; }

    }
}
