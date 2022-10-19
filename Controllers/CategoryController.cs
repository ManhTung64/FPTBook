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
            var categories = context.Categories.ToList();
            return View(categories);
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
        [Authorize(Roles = "admin")]
        public IActionResult ListRequest()
        {
            var requests = context.Requests.ToList();
            if (requests.Count == 0) return View();
            TempData["message"] = "not request";
            return View();
        }
        public IActionResult ConfirmRequest(int? id)
        {
            if (id == null) return NotFound();
            return View(context.Requests.Find(id));
        }
        public IActionResult Remove(int id)
        {
            var university = context.Categories.Find(id);
            context.Categories.Remove(university);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
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
        public IActionResult RemoveRequest(int? id)
        {
            if(id == null) return NotFound();
            context.Requests.Remove(context.Requests.Find(id));
            TempData["message"] = "Delete successful";
            return RedirectToAction("ListRequest");
        }
        private Category ConvertData(Request request)
        {
            return new Category { Id =  request.Id, Name = request.Name,Description = request.Description};
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //kiểm tra thông tin nhập vào từ form
            if (ModelState.IsValid)
            {
                //nếu hợp lệ thì cập nhật vào db
                context.Categories.Update(category);
                //lưu thay đổi vào db
                context.SaveChanges();
                //return về trang index
                return RedirectToAction("Index");
                //return RedirectToAction(nameof(Index));
            }
            //nếu không hợp lệ thì quay ngược về form 
            return View(category);
        }
    }
}
