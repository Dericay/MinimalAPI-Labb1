using BooksLibrary.Models;
using BooksLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI_Labb1.Models.DTOs;
using Newtonsoft.Json;

namespace BooksLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        public async Task<IActionResult> BookIndex()
        {
            List<BooksDTO> List = new List<BooksDTO>();
            var response = await _bookService.GetAllBooks<ResponseDto>();
            if(response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<BooksDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
        }

        public async Task<IActionResult> Details(int id)
        {
            BooksDTO bDto = new BooksDTO();

            var response = await _bookService.GetBookById<ResponseDto>(id);
            if(response != null && response.IsSuccess)
            {
                BooksDTO model = JsonConvert.DeserializeObject<BooksDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return View();
        }

        public async Task<IActionResult> AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BooksDTO model)
        {
            if(ModelState.IsValid)
            {
                var response = await _bookService.AddBookAsync<ResponseDto>(model);
                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }                
            }
            return View(model);
        }
        public async Task<IActionResult> UpdateBook(int bookId)
        {
            var response = await _bookService.GetBookById<ResponseDto>(bookId);
            if(response != null && response.IsSuccess)
            {
                BooksDTO model = JsonConvert.DeserializeObject<BooksDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BooksDTO model)
        {
            if(ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ResponseDto>(model);
                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var response = await _bookService.GetBookById<ResponseDto>(bookId);
            if(response != null && response.IsSuccess)
            {
                BooksDTO model = JsonConvert.DeserializeObject<BooksDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BooksDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.DeleteBookAsync<ResponseDto>(model.ID);
                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Browse()
        {
            var response = await _bookService.GetAllBooks<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                var books = JsonConvert.DeserializeObject<List<BooksDTO>>(Convert.ToString(response.Result));
                var availableBooks = books.Where(b => b.IsAvailable).ToList();
                return View(availableBooks);
            }
            return View(new List<BooksDTO>());
        }
    }
}
