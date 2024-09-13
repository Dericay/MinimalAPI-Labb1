using MinimalAPI_Labb1.Models.DTOs;

namespace BooksLibrary.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookService(IHttpClientFactory clientFactory): base(clientFactory)
        {
            this._httpClientFactory = clientFactory;
        }

        public async Task<T> AddBookAsync<T>(BooksDTO booksDTO)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                apiType = StaticDetails.ApiType.POST,
                Data = booksDTO,
                Url = StaticDetails.BooksApiBase + "/api/book",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                apiType= StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BooksApiBase + "/api/book/" + id,
                AccessToken = ""
            });
        }

        public Task<T> GetAllBooks<T>()
        {
            return this.SendAsync<T>(new Models.APIRequest
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BooksApiBase + "/api/books",
                AccessToken = ""
            });
        }

        public Task<T> GetBookById<T>(int id)
        {
            return this.SendAsync<T>(new Models.APIRequest
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BooksApiBase + "/api/book/" + id
            });
        }

        public Task<T> UpdateBookAsync<T>(BooksDTO booksDTO)
        {
            return this.SendAsync<T>(new Models.APIRequest
            {
                apiType = StaticDetails.ApiType.PUT,
                Data = booksDTO,
                Url = StaticDetails.BooksApiBase + "/api/book",
                AccessToken = ""
            });
        }
    }
}
