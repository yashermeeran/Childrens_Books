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

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(string category)
        {
            return await _context.Books.Where(b => b.Category == category).ToListAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.Books
                .Select(b => b.Category)
                .Distinct()
                .ToListAsync();

            return categories
                .Select((category, index) => new CategoryDto { Id = index + 1, Category = category }) 
                .ToList();
        }

        public async Task<string?> GetBookContentAsync(int bookId, int pageNumber)
        {
            var content = await _context.BookPages
                .Where(bp => bp.BookId == bookId && bp.PageNumber == pageNumber)
                .Select(bp => bp.Text)
                .FirstOrDefaultAsync(); 

            return content ?? "No content found for this page."; 
        }
    }
}
