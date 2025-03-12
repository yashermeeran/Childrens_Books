using Microsoft.EntityFrameworkCore;
using KidsBooks.Models;

namespace KidsBooks.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<BookPage> BookPages { get; set; } = default!; 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Ignore(b => b.SomeProperty); 
        }

        private static string GetText(Book b)
        {
            return b.Text;
        }
    }
}
