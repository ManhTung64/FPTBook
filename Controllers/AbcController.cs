using Microsoft.AspNetCore.Mvc;

namespace FPTBook.Controllers
{
    public class AbcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
