using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.listShopItems = shopCart.GetShopItems();
            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Add orders");
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
                return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Order completed";
            return View();
        }
    }
}
