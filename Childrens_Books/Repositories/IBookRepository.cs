using KidsBooks.Models;

namespace KidsBooks.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);    // ✅ Fix: Add this method
        Task UpdateBookAsync(Book book); // ✅ Fix: Add this method
        Task DeleteBookAsync(int id);    // ✅ Fix: Add this method
    }
}
