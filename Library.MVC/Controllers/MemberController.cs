using Library.BL;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMembersService _membersService;

        public MemberController(IMembersService membersService)
        {
            _membersService = membersService;
        }
        public IActionResult Index()
        {
            var members = _membersService.GetAll();
            return View(members);
        }
        public IActionResult Details(Guid id)
        {
            var member = _membersService.GetDetails(id);
            return View(member);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MemberAddVM member)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Request request = _membersService.Add(member);

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
            Request request = _membersService.Delete(id);
            TempData[Message.Status] = request.Status;
            TempData[Message.Mess] = request.Message;

            return RedirectToAction(nameof(Index));
        }
    }
}
