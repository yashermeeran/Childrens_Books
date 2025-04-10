﻿using KidsBooks.Models;
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

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Bookmarks>>> GetUserBookmarks(int userId)
        {
            var bookmarks = await _bookmarksRepository.GetUserBookmarksAsync(userId);
            return Ok(bookmarks);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookmark([FromBody] Childrens_Books.Models.CreateBookmarkDto createBookmarkDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookmark = new Bookmarks
            {
                UserId = createBookmarkDto.UserId,
                BookId = createBookmarkDto.BookId,
                PageNumber = createBookmarkDto.PageNumber
            };

            try
            {
                var existingBookmarks = await _bookmarksRepository.GetUserBookmarksAsync(createBookmarkDto.UserId);
                var existingBookmark = existingBookmarks.FirstOrDefault(b => b.BookId == createBookmarkDto.BookId);

                if (existingBookmark != null)
                {
                    existingBookmark.PageNumber = createBookmarkDto.PageNumber;
                    var updatedBookmark = await _bookmarksRepository.UpdateBookmarkAsync(existingBookmark);
                    return Ok(updatedBookmark);
                }

                var createdBookmark = await _bookmarksRepository.AddBookmarkAsync(bookmark);
                return CreatedAtAction(nameof(GetUserBookmarks), new { userId = createdBookmark.UserId }, createdBookmark);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookmark(int id)
        {
            var result = await _bookmarksRepository.DeleteBookmarkAsync(id);
            if (!result)
            {
                return NotFound("Bookmark not found.");
            }
            return Ok(new { message = "Bookmark deleted successfully" });
        }

    }
}