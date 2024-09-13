using MinimalAPI_Labb1.Models;

namespace MinimalAPI_Labb1.Repository
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Books>> GetAllAsync();
        Task<Books> GetAsync(int id);
        Task<Books> GetAsync(string bookName);
        Task CreateAsync(Books book);
        Task UpdateAsync(Books book);
        Task RemoveAsync(Books book);
        Task SaveAsync();
    }
}
