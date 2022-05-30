using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _Product;

        public ProductController(IProduct Product)
        {
            _Product  = Product;
        }
        public async Task<IActionResult> Index()
        {
            var ListProduct = await _Product.GetProducts();
            return View(ListProduct);
        }

        public async Task<IActionResult> Details(int id)
        {
            Product product = await _Product.GetProduct(id);

            return View(product);
        }
    }
}
