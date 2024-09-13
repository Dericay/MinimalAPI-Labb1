using Microsoft.EntityFrameworkCore;
using MinimalAPI_Labb1.Data;
using MinimalAPI_Labb1.Models;

namespace MinimalAPI_Labb1.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _db;

        public BooksRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Books book)
        {
            _db.Books.AddAsync(book);
        }

        public async Task<IEnumerable<Books>> GetAllAsync()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Books> GetAsync(int id)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task<Books> GetAsync(string bookName)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.BookTitle == bookName.ToLower());
        }

        public async Task RemoveAsync(Books book)
        {
            _db.Books.Remove(book);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Books book)
        {
            _db.Books.Update(book);
        }
    }
}
