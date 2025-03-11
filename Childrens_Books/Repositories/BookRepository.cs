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
            return await _context.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book); // ✅ Fix: Adds a new book
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book); // ✅ Fix: Updates an existing book
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book); // ✅ Fix: Deletes the book
                await _context.SaveChangesAsync();
            }
        }
    }
}
