using KidsBooks.Data;
using KidsBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace KidsBooks.Repositories
{
    public class BookmarksRepository : IBookmarksRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookmarksRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<IEnumerable<Bookmarks>> GetUserBookmarksAsync(int userId)
        {
            return await _appDbContext.Bookmarks
                .Where(b => b.UserId == userId)
                .Include(b => b.Book) 
                .ToListAsync();
        }

        public async Task<Bookmarks> AddBookmarkAsync(Bookmarks bookmark)
        {
           
            var existingBook = await _appDbContext.Books.FindAsync(bookmark.BookId);
            if (existingBook == null)
            {
                throw new ArgumentException("Invalid BookId. The book does not exist.");
            }

            bookmark.Book = existingBook;
            bookmark.CreatedAt = DateTime.UtcNow; 
            _appDbContext.Bookmarks.Add(bookmark);
            await _appDbContext.SaveChangesAsync();
            return bookmark;
        }

        public async Task<Bookmarks> GetBookmarkByIdAsync(int id)
        {
            return await _appDbContext.Bookmarks
                .Include(b => b.Book) 
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<bool> DeleteBookmarkAsync(int id)
        {
            var bookmark = await _appDbContext.Bookmarks.FindAsync(id);
            if (bookmark == null)
            {
                return false;
            }

            _appDbContext.Bookmarks.Remove(bookmark);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public Task<Bookmarks> UpdateBookmarkAsync(Bookmarks existingBookmark)
        {
            throw new NotImplementedException();
        }
    }
}