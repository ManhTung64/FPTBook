using Microsoft.AspNetCore.Mvc;

namespace FPTBook.Controllers
{
    public class TrashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
