using Library.BL;
using Library.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMembersService _membersService;
        private readonly IBooksService _booksService;
        private readonly IBookMembersService _booksMembersService;
        public HomeController(ILogger<HomeController> logger,
           IMembersService membersService, IBooksService booksService
            ,IBookMembersService booksMembersService)
        {
            _logger = logger;
            _membersService = membersService;
            _booksService = booksService;
            _booksMembersService = booksMembersService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Guid memberId, Guid bookId, string actionType)
        {
            if (string.IsNullOrEmpty(memberId.ToString()) || string.IsNullOrEmpty(bookId.ToString()) || string.IsNullOrEmpty(actionType))
            {
                TempData["AlertMessage"] = "Please select all the dropdown values.";
                return View();
            }
            else if (actionType == "Borrow")
            {
                _booksMembersService.BorrowBook(memberId, bookId);
            }
            else if (actionType == "Lend")
            {
                _booksMembersService.LendBook(memberId, bookId);
            }
            return RedirectToAction("Index", "Book");
        }
        public IActionResult GetBooks(Guid memberId, string actionType)
        {
            IEnumerable<Book> books =  new List<Book>();
            if (actionType == "Borrow")
            {
                books = _booksService.GetAvailableBooks(memberId);
            }
            else if (actionType == "Lend")
            {
                books = _booksService.GetBorrowedBooks(memberId);
            }
            return Json(books);
        }
        public IActionResult GetMembers()
        {
            var members = _membersService.GetAll();
            return Json(members);
        }
        public IActionResult MemberWithBook()
        {
            var MemberBook = _booksMembersService.GetAll();
            return View(MemberBook);
        }
    }
}