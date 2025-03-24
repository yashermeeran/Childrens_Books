using KidsBooks.DTOs;
using KidsBooks.Models;
using KidsBooks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KidsBooks.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllCategories()
        {
            var categories = await _bookRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByCategory(string category)
        {
            var books = await _bookRepository.GetBooksByCategoryAsync(category);
            if (!books.Any())
            {
                return NotFound("No books found in this category.");
            }
            return Ok(books);
        }

        [HttpGet("{id}/content")]
        public async Task<ActionResult<BookContentDto>> GetBookContent(int id, [FromQuery] int page = 1)
        {
            var content = await _bookRepository.GetBookContentAsync(id, page);
            if (content == null)
            {
                return NotFound("No content found for this book page.");
            }

            var totalPages = await _bookRepository.GetTotalPagesAsync(id);

            var bookContentDto = new BookContentDto
            {
                BookId = id,
                PageNumber = page,
                TotalPages = totalPages,
                Content = content
            };

            return Ok(bookContentDto);
        }
    }
}
