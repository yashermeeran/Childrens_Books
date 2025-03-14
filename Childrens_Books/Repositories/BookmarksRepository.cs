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

        public async Task<IEnumerable<Bookmarks>> GetUserBookmarksAsync()
        {
            return await _appDbContext.Set<Bookmarks>().ToListAsync();
        }
    }
}