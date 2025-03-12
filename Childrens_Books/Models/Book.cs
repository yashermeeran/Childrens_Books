using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KidsBooks.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        public string? CoverImageUrl { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<BookPage> BookPages { get; set; } = new List<BookPage>();

        [NotMapped] 
        public string Text => GetText();

        public object? SomeProperty { get; internal set; }

        private string GetText()
        {
            return "Some text";
        }
    }
}
