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

<<<<<<< HEAD
        public IActionResult Detail(int id)
        {
            return View(context.Categories.Include(book => book.books).FirstOrDefault(category => category.Id == id));
=======
        /*public IActionResult Info(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories
                                    .Include(c => c.books)
                                    .FirstOrDefault(u => u.Id == id);
            //Note: khi muốn truy xuất dữ liệu của bảng B từ bảng A
            //thì cần sử dụng Include kết hợp với FirstOrDefault
            //còn nếu chỉ truy xuất thông tin id đơn thuần thì sử dụng
            //Find hoặc FirstOrDefault đều được
            return View(category);
        }*/

        public IActionResult Remove(int id)
        {
            var university = context.Categories.Find(id);
            context.Categories.Remove(university);
            context.SaveChanges();
            return RedirectToAction("Index");
>>>>>>> 604c4acbbd2f2348f3fec241e567cb7c20676695
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
<<<<<<< HEAD
            return View(context.Categories.Find(id));
=======
            var category = context.Categories.Find(id);
            return View(category);
>>>>>>> 604c4acbbd2f2348f3fec241e567cb7c20676695
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
<<<<<<< HEAD
                context.Categories.Update(category);
=======
                //nếu hợp lệ thì cập nhật vào db
                context.Categories.Update(category);
                //lưu thay đổi vào db
>>>>>>> 604c4acbbd2f2348f3fec241e567cb7c20676695
                context.SaveChanges();
                return RedirectToAction("Index");
            }
<<<<<<< HEAD
            return View(category);
        }

        public IActionResult Remove(int id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
=======
            //nếu không hợp lệ thì quay ngược về form 
            return View(category);
        }
>>>>>>> 604c4acbbd2f2348f3fec241e567cb7c20676695
    }
}
