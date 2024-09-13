using MinimalAPI_Labb1.Models.DTOs;

namespace BooksLibrary.Services
{
    public interface IBookService
    {

        Task<T> GetAllBooks<T>();

        Task<T> GetBookById<T>(int id);

        Task<T> AddBookAsync<T>(BooksDTO booksDTO);

        Task<T> UpdateBookAsync<T>(BooksDTO booksDTO);

        Task<T> DeleteBookAsync<T>(int id);
    }
}
