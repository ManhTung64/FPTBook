using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IActionResult Index()
        {
            return View(context.Books.ToList());
        }
        [HttpGet]
        public IActionResult CheckOut(int id)
        {
            var book = context.Books.Find(id);
            ViewBag.Title = book.Title;
            ViewBag.Quantity = book.Quantity;
            ViewBag.Id = id;
            ViewBag.Price = book.Price;
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Bill bill, double price)
        {
            bill.OrderDate = DateTime.Now.Date;
            bill.Price = price * bill.Quantity;
            bill.Id = context.Bills.ToList().Count + 1;
            context.Bills.Add(bill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ListBill()
        {
            return View(context.Bills.ToList());
        }
        public IActionResult ListBillOfCustomer()
        {
            return View(context.Bills.Where(b=>b.CustomerEmail.Equals(User.Identity.Name)).ToList());
        }
    }
}
