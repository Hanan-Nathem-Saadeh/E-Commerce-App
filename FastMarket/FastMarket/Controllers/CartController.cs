using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;

        public CartController(ICart Cart)
        {
            _cart = Cart;
        }

        public async  Task<IActionResult> Index()
        {
            var ListCart = await _cart.GetCarts();
            return View(ListCart);
        }

        public async Task<IActionResult> Details(int id)
        {

            var cart = await _cart.GetCart(id);
            return View(cart);
        }
    }
}
