using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KidsBooks.Models
{
    public class BookPage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        public int PageNumber { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public virtual Book Book { get; set; } 
    }
}
