using Microsoft.AspNetCore.Mvc;

namespace FPTBook.Controllers
{
    public class AhihiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
