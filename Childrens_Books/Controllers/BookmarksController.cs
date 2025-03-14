using KidsBooks.Models;
using KidsBooks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KidsBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IBookmarksRepository _bookmarksRepository;

        public BookmarksController(IBookmarksRepository bookmarksRepository)
        {
            _bookmarksRepository = bookmarksRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookmarks>>> GetUserBookmarks()
        {
            var bookmarks = await _bookmarksRepository.GetUserBookmarksAsync();
            return Ok(bookmarks);
        }
    }
}