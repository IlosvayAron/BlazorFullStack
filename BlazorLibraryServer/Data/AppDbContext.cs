using BlazorFullStack.Contract;
using Microsoft.EntityFrameworkCore;

namespace BlazorLibraryServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
    }
}
