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
            return View();
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }
    }
}
