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

        [Authorize(Roles = "StoreOwner")]
        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        [Authorize(Roles = "StoreOwner")]
        public IActionResult Detail(int id)
        {
            return View(context.Categories.Include(book => book.books).FirstOrDefault(category => category.Id == id));
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult SendRequest()
        {
            return View();
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public IActionResult SendRequest(Request request)
        {
            if (ModelState.IsValid)
            {
                context.Requests.Add(request);
                context.SaveChanges();
                TempData["message"] = "Send successful, please wait admin access";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(context.Categories.Find(id));
        }

        [Authorize(Roles = "StoreOwner")]
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

        [Authorize(Roles = "StoreOwner")]
        public IActionResult Remove(int id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ListRequest()
        {
            var requests = context.Requests.ToList();
            if (requests.Count == 0) return View();
            TempData["message"] = "not request";
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult ConfirmRequest(int id)
        {
            return View("SendRequest",context.Requests.Find(id));
        }

        [HttpPost]
        public IActionResult ConfirmRequest(Request request)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add( new Category { Name = request.Name, Description = request.Description });
                context.Requests.Remove(request);
                context.SaveChanges();
                TempData["message"] = "Add successful";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult RemoveRequest(int id)
        {
            context.Requests.Remove(context.Requests.Find(id));
            TempData["message"] = "Delete successful";
            return RedirectToAction("ListRequest");
        }
    }
}
