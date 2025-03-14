using KidsBooks.Models;

namespace KidsBooks.Repositories
{
    public interface IBookmarksRepository
    {
        Task<IEnumerable<Bookmarks>> GetUserBookmarksAsync();
    }
}