using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace FPTBook.Controllers
{
    public class BookController : Controller
    {
        //attribute
        private readonly ApplicationDbContext context;

        //constructor (auto-generate : Alt+Enter => Generate constructor)
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(context.Books.ToList());
        }

        public IActionResult List()
        {
            return View(context.Books.ToList());
        }

        //[Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                //nếu id không tìm thấy thì trả về not found
                return NotFound();
            }
            else
            {
                //tìm ra object student có id được yêu cầu
                var book = context.Books.Find(id);
                //xóa object student vừa tìm thấy
                context.Books.Remove(book);
                //lưu lại thay đổi trong db
                context.SaveChanges();

                //gửi thông báo về trang Index
                //bắt buộc dùng TempData để có thể gửi dữ liệu về View nếu return RedirectToAction
                TempData["Message"] = "Delete book successfully !";

                //quay trở lại trang index sau khi thành công
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Detail(int id)
        {
            var book = context.Books
                                 .Include(b => b.Category)
                                 .FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Add()
        {
            //lấy ra dữ liệu từ bảng University và lưu vào list
            var categories = context.Categories.ToList();
            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                TempData["Message"] = "Add student successfully !";
                return RedirectToAction("index");
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
            //lấy ra dữ liệu từ bảng University và lưu vào list
            var categories = context.Categories.ToList();
            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;
            return View(context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                TempData["Message"] = "Edit student successfully !";
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }
        }
    }
}
