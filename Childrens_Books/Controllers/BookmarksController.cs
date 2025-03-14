using KidsBooks.Models;
using KidsBooks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KidsBooks.Controllers
{
    [Route("api/bookmarks")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IBookmarksRepository _bookmarksRepository;

        public BookmarksController(IBookmarksRepository bookmarksRepository)
        {
            _bookmarksRepository = bookmarksRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Bookmarks>>> GetUserBookmarks(int userId)
        {
            var bookmarks = await _bookmarksRepository.GetUserBookmarksAsync(userId);
            return Ok(bookmarks);
        }
    }
}
