using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FPTBook.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Books.ToList());
        }

        public IActionResult List()
        {
            return View(context.Books.ToList());
        }

        public IActionResult Detail(int id)
        {
            return View(context.Books.Include(category => category.Category).FirstOrDefault(book => book.Id == id));
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                TempData["Message"] = "Add book successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = context.Categories.ToList();
            return View(context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                TempData["Message"] = "Edit book successfully !";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }
        }
        public IActionResult Delete(int id)
        {
            context.Books.Remove(context.Books.Find(id));
            context.SaveChanges();
            TempData["Message"] = "Delete book successfully !";
            return RedirectToAction("Index");
        }

        
    }
}
