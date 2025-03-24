using KidsBooks.Models;

namespace KidsBooks.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetBooksByCategoryAsync(string category);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<string?> GetBookContentAsync(int bookId, int pageNumber);
        Task<int> GetTotalPagesAsync(int bookId); 
    }
}
