using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MinimalAPI_Labb1.Models;
using System.Runtime.CompilerServices;
using AutoMapper;
using MinimalAPI_Labb1.Repository;
using MinimalAPI_Labb1.Models.DTOs;

namespace MinimalAPI_Labb1.EndPoints
{
    public static class BooksEndpoints
    {
        public static void ConfigurationBooksEndpoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAllBooks).WithName("GetBooks").Produces<APIRespons>();
            app.MapGet("/api/book/{id:int}", GetBook).WithName("GetBook").Produces<APIRespons>();
            app.MapPost("/api/book", AddBook).WithName("AddBook").Accepts<BooksCreateDTO>("application/json").Produces(201).Produces(400);
            app.MapPut("/api/book", UpdateBook).WithName("UpdateBook").Accepts<BooksUpdateDTO>("application/json").Produces<BooksUpdateDTO>(200).Produces(400);
            app.MapDelete("/api/book/{id:int}", DeleteBook).WithName("DeleteBook");
        }




        private async static Task<IResult> GetAllBooks(IBooksRepository _bookRepo)
        {
            APIRespons response = new APIRespons();

            response.Result = await _bookRepo.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> GetBook(IBooksRepository _bookRepo, int id)
        {
            APIRespons respons = new APIRespons();
            respons.Result = await _bookRepo.GetAsync(id);
            respons.IsSuccess = true;
            respons.StatusCode =System.Net.HttpStatusCode.OK;

            return Results.Ok(respons);
        }

        private async static Task<IResult> AddBook(IBooksRepository _bookRepo, IMapper _mapper, BooksCreateDTO book_c_DTO)
        {
            APIRespons response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            if (_bookRepo.GetAsync(book_c_DTO.BookTitle).GetAwaiter().GetResult() != null)
            {
                response.ErrorMessages.Add("Book title already taken");
                return Results.BadRequest(response);
            }
            Books book = _mapper.Map<Books>(book_c_DTO);
            await _bookRepo.CreateAsync(book);
            await _bookRepo.SaveAsync();
            BooksDTO booksDto = _mapper.Map<BooksDTO>(book);

            response.Result = booksDto;
            response.IsSuccess = true;
            response.StatusCode=System.Net.HttpStatusCode.Created;
            return Results.Ok(response);
        }
        private async static Task<IResult> UpdateBook(IBooksRepository _bookRepo, IMapper _mapper, BooksUpdateDTO book_U_DTO)
        {
            APIRespons response = new APIRespons()
            {
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
            await _bookRepo.UpdateAsync(_mapper.Map<Books>(book_U_DTO));
            await _bookRepo.SaveAsync();
            response.Result = _mapper.Map<BooksUpdateDTO>(await _bookRepo.GetAsync(book_U_DTO.ID));
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return Results.Ok(response);
        }

        private async static Task<IResult> DeleteBook(IBooksRepository _bookRepo, int id)
        {
            APIRespons response = new APIRespons() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
            Books bookFromDB = await _bookRepo.GetAsync(id);
            if(bookFromDB != null)
            {
                await _bookRepo.RemoveAsync(bookFromDB);
                await _bookRepo.SaveAsync();
                response.IsSuccess=true;
                response.StatusCode=System.Net.HttpStatusCode.NoContent;
            }
            else
            {
                response.ErrorMessages.Add("Invalid ID"); ;
                return Results.BadRequest(response);
            }
            return Results.Ok(response);
        }
    }
}
