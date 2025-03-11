using KidsBooks.Controllers;
using KidsBooks.Data;   
using KidsBooks.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KidsBooks.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        Task IBookRepository.GetAllBooksAsync()
        {
            return GetAllBooksAsync();
        }
    }

    internal class AppDbContext
    {
        public object Books { get; internal set; }
    }
}
