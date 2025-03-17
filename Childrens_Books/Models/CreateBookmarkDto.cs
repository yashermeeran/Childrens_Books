using System.ComponentModel.DataAnnotations;

namespace Childrens_Books.Models
{
    public class CreateBookmarkDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int PageNumber { get; set; }
    }
}
