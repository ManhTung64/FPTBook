using FPTBook.Data;
using FPTBook.Helpers;
using FPTBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FPTBook.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext context;

        public CustomerController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Route("/")]
        public IActionResult Index()
        {
            DataCart();
            return View(context.Books.ToList());
        }
        private void DataCart()
        {
            ViewBag.Categories = context.Categories.ToList();
            try
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart").ToList();
                for (int i = 0; i < cart.Count && i < 3; i++)
                {
                    ViewData["Title" + i + ""] = cart[i].book.Title;
                    ViewData["Image" + i + ""] = cart[i].book.Image;
                    ViewBag.count = i + 1;
                }
            }
            catch (ArgumentNullException a)
            {
                TempData["MessageNull"] = "Please add book to your cart !!!";
            }
        }
        
        public IActionResult CheckOut(Bill bill)
        {
            bill.OrderDate = DateTime.Now.Date;
            bill.Id = context.Bills.ToList().Count + 1;
            context.Bills.Add(bill);
            context.SaveChanges();
            return RedirectToAction("ListBillOfCustomer");
        }
        public IActionResult ListBill()
        {
            return View(context.Bills.ToList());
        }
        public IActionResult ListBillOfCustomer()
        {
            return View(context.Bills.Where(bill=>bill.CustomerEmail.Equals(User.Identity.Name)).ToList());
        }
        public IActionResult ListAccountStoreOwner()
        {
            LinkedList<IdentityUser> accounts = new LinkedList<IdentityUser>();
                var storeOwnerRole = context.UserRoles.Where(s=>s.RoleId.Equals("storeOwner")).ToList();
                if (storeOwnerRole != null)
                {
                    foreach(var item in storeOwnerRole)
                    {  
                        accounts.AddLast(context.Users.Find(item.UserId));
                    }
                  return View("ListAccount",accounts);
                }
               TempData["message"] = "No any account !!!";
               return View("ListAccount");
        }
        public IActionResult ListAccountCustomer()
        {
            LinkedList<IdentityUser> accounts = new LinkedList<IdentityUser>();
            var storeOwnerRole = context.UserRoles.Where(s => s.RoleId.Equals("customer")).ToList();
            if (storeOwnerRole != null)
            {
                foreach (var item in storeOwnerRole)
                {
                    accounts.AddLast(context.Users.Find(item.UserId));
                }
                return View("ListAccount",accounts);
            }
            TempData["message"] = "No any account !!!";
            return View("ListAccount");
        }
        [HttpPost]
        public IActionResult ChangePassword(string id, string pass)
        {
            //var hasher = PasswordHasher<IdentityUser>();
            
            var account = context.Users.Find(id);
            var hasher = new PasswordHasher<IdentityUser>();
            account.PasswordHash = hasher.HashPassword(account,pass);
            context.SaveChanges();
            return RedirectToAction("ListAccountCustomer");
        }

        
        public IActionResult SortTitleAsc()
        {
            DataCart();
            return View("Index", context.Books.OrderBy(s => s.Title).ToList());
        }

        public IActionResult SortTitleDesc()
        {
            DataCart();
            return View("Index", context.Books.OrderByDescending(s => s.Title).ToList());
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            DataCart();
            var books = context.Books.Where(s => s.Title.Contains(keyword)).ToList();
            if (books.Count == 0)
            {
                TempData["Message"] = "No student found";
            }
            return View("Index", books);
        }

        public IActionResult SortPriceAsc()
        {
            DataCart();
            return View("Index", context.Books.OrderBy(s => s.Price).ToList());
        }

        public IActionResult SortPriceDesc()
        {
            DataCart();
            return View("Index", context.Books.OrderByDescending(s => s.Price).ToList());
        }

        public IActionResult Detail(int id)
        {
            return View(context.Books.Include(category => category.Category).FirstOrDefault(book => book.Id == id));
        }

        public IActionResult Info(int id)
        {
            var book = context.Books
                                 .Include(s => s.Category)
                                 .FirstOrDefault(s => s.Id == id);
            return View(book);
        }
    }
}
