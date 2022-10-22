using FPTBook.Data;
using FPTBook.Helpers;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FPTBook.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext context;
        private static int count = 0;

        public CartController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart").ToList();
            return View(cart);
        }

        public IActionResult AddToCart(int Id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Id = count++, book = context.Books.Find(Id), Item_Quantity = 1, Total = context.Books.Find(Id).Price * 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(Id);
                if (index != -1)
                {
                    cart[index].Item_Quantity++;
                }
                else
                {
                    cart.Add(new Item {Id = count++, book = context.Books.Find(Id), Item_Quantity = 1, Total = context.Books.Find(Id).Price * 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                cart.RemoveAt(index);
                cart[index + 1].Id = count--;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                TempData["MessageRemove"] = "An error has been happened!";
            }
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].book.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult IncreaseQuantityToOne(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart[id].Item_Quantity < cart[id].book.Quantity)
            {
                cart[id].Item_Quantity++;
                cart[id].Total = cart[id].book.Price * cart[id].Item_Quantity;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                TempData["MessageIncrease"] = "The remaning books is " + cart[id].book.Quantity + "!";
            }
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseQuantityToOne(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart[id].Item_Quantity > 1)
            {
                cart[id].Item_Quantity--;
                cart[id].Total = cart[id].book.Price * cart[id].Item_Quantity;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                TempData["MessageDecrease"] = "The quantity cannot smaller than 0!";
            }
            return RedirectToAction("Index");
        }
    }
}
