using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;

namespace FPTBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public IActionResult Detail(int id)
        {
            return View(context.Categories.Include(book => book.books).FirstOrDefault(category => category.Id == id));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(context.Categories.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Remove(int id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SendRequest(Request category)
        {
            if (ModelState.IsValid)
            {
                context.Requests.Add(category);
                context.SaveChanges();
                TempData["message"] = "Send successful, please wait admin access";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Add(Request category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(ConvertData(category));
                context.Requests.Remove(category);
                context.SaveChanges();
                TempData["message"] = "Add successful";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        private Category ConvertData(Request request)
        {
            return new Category { Id = request.Id, Name = request.Name, Description = request.Description };
        }
        [HttpPost]

        public IActionResult RemoveRequest(int? id)
        {
            if (id == null) return NotFound();
            context.Requests.Remove(context.Requests.Find(id));
            TempData["message"] = "Delete successful";
            return RedirectToAction("ListRequest");
        }
        public IActionResult ConfirmRequest(int? id)
        {
            if (id == null) return NotFound();
            return View(context.Requests.Find(id));
        }
        [Authorize(Roles = "admin")]
        public IActionResult ListRequest()
        {
            var requests = context.Requests.ToList();
            if (requests.Count == 0) return View();
            TempData["message"] = "not request";
            return View();
        }
    }
}
