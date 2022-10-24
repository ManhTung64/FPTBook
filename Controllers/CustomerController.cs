﻿using FPTBook.Data;
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
        [HttpGet]
        public IActionResult CheckOut(int id)
        {
            DataCart();

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
            return RedirectToAction("ListBillOfCustomer");
        }
        public IActionResult ListBill()
        {
            return View(context.Bills.ToList());
        }
        public IActionResult ListBillOfCustomer()
        {
            return View(context.Bills.Where(b=>b.CustomerEmail.Equals(User.Identity.Name)).ToList());
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
    }
}
