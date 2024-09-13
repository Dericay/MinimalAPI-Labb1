

namespace BookLibrary.Services
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();

        Task<T> GetBookById<T>(int id);

        Task<T> AddBookAsync<T>(BooksDTO bookDTO);
    }
}
