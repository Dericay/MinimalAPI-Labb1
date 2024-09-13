using BooksLibrary.Models;
using System;

namespace BooksLibrary.Services
{
    public interface IBaseService:IDisposable
    {
        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
