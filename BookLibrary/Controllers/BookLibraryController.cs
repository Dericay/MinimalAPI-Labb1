using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class BookLibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
