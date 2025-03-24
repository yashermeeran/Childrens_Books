namespace KidsBooks.DTOs
{
    public class BookContentDto
    {
        public int BookId { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; } 
        public string Content { get; set; }
    }
}

