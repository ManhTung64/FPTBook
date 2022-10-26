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
        [Route("/StoreOwner/Category")]
        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        [Authorize(Roles = "StoreOwner")]
        [Route("/StoreOwner/DetailCategory")]
        public IActionResult Detail(int id)
        {
            return View(context.Categories.Include(book => book.books).FirstOrDefault(category => category.Id == id));
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        [Route("/StoreOwner/SendRequest")]
        public IActionResult SendRequest()
        {
            return View();
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
        [Route("/StoreOwner/RemoveCategory")]
        public IActionResult Remove(int id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator,StoreOwner")]
        [Route("/ListRequest")]
        public IActionResult ListRequest()
        {
            var requests = context.Requests.ToList();
            if (requests.Count == 0)
            {
                TempData["message"] = "No request !!";
                return View();
            }
            return View(requests);
        }

        [Authorize(Roles = "StoreOwner")]
        [Route("/StoreOwner/SendRequest")]
        [HttpPost]
        public IActionResult SendRequest(Request request)
        {
            if (ModelState.IsValid)
            {
                request.Status = "Pending";
                context.Requests.Add(request);
                context.SaveChanges();
                TempData["message"] = "Send successful, please waiting admin access";
                return RedirectToAction("ListRequest");
            }
            return View(request);
        }
        [Route("/StoreOwner/ConfirmRequest")]
        [Authorize(Roles = "Administrator")]
        public IActionResult ConfirmRequest(int id)
        {
            var request = context.Requests.Find(id);
            context.Categories.Add( new Category { Name = request.Name, Description = request.Description });
            request.Status = "Approval";
            context.SaveChanges();
            TempData["message"] = "Approval successful";
            return RedirectToAction("ListRequest");
        }

        [Authorize(Roles = "Administrator")]
        [Route("/Admin/RejectRequest")]
        public IActionResult RejectRequest(int id)
        {
            context.Requests.Find(id).Status = "Reject";
            context.SaveChanges();
            TempData["message"] = "Reject successful";
            return RedirectToAction("ListRequest");
        }
    }
}
