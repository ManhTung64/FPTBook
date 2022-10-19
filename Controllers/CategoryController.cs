using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
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
    }
}
