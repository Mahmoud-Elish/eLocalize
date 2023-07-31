using Library.BL;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksService _booksService;

        public BookController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        public IActionResult Index()
        {
            var books = _booksService.GetAll();
            return View(books);
        }
        public IActionResult Details(Guid id)
        {
            var book = _booksService.GetDetails(id);
            return View(book);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookAddVM book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Request request = _booksService.Add(book);
            TempData[Message.Status] = request.Status;
            TempData[Message.Mess] = request.Message;
            if (request.Status)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete(Guid id)
        {
            Request request = _booksService.Delete(id);
            TempData[Message.Status] = request.Status;
            TempData[Message.Mess] = request.Message;
            return RedirectToAction(nameof(Index));
        }
    }

}