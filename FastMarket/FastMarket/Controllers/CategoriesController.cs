using FastMarket.Data;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategories _Categories;

        public CategoriesController(ICategories Categories)
        {
            _Categories = Categories;
        }
        public async Task<IActionResult> Index()
        {
            var list1 = await _Categories.GetCategories();

            return View(list1);
        }
        public async Task<IActionResult> Details(int id)
        {
            var category = await _Categories.GetCategory(id);

            return View(category);
        }
    }
}
