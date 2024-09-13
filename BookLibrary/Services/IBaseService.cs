using BookLibrary.Models;

namespace BookLibrary.Services
{
    public interface IBaseService
    {
        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
