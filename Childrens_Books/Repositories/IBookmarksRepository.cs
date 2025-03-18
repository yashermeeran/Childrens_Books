using KidsBooks.Models;

namespace KidsBooks.Repositories
{
    public interface IBookmarksRepository
    {
        Task<IEnumerable<Bookmarks>> GetUserBookmarksAsync(int userId);
        Task<Bookmarks> AddBookmarkAsync(Bookmarks bookmark);
        Task<bool> DeleteBookmarkAsync(int id);


    }
}