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

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(string category)
        {
            return await _context.Books.Where(b => b.Category == category).ToListAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _context.Books
                .Select(b => new CategoryDto { Category = b.Category })
                .Distinct()
                .ToListAsync();
        }

        public async Task<string?> GetBookContentAsync(int bookId, int pageNumber)
        {
            var bookPage = await _context.BookPages
                .FirstOrDefaultAsync(bp => bp.BookId == bookId && bp.PageNumber == pageNumber);

            return bookPage?.Text;
        }

        public async Task<int> GetTotalPagesAsync(int bookId)
        {
            return await _context.BookPages.CountAsync(bp => bp.BookId == bookId);
        }
    }
 
}