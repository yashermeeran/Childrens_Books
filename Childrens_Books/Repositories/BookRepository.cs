using KidsBooks.Data;
using KidsBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace KidsBooks.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
