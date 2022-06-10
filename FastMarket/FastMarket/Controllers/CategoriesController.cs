using FastMarket.Data;
using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Http;
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

            ViewBag.Title = id;

            return View(category);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Categories category = await _Categories.GetCategory(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Categories category)
        {     
            if (ModelState.IsValid)
            {
                Categories categories = await _Categories.UpdateCategories(category.Id, category);
                return Content("Updated Successfully :) ");
            }
            else
            {
                    return View(category);
            }              
            
        }
        public IActionResult Add()
        {
             return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Categories category)
        {
            if (ModelState.IsValid)
            {
               await _Categories.Create(category);
                return Content("Add new Category Successfully ... :)");
            }
            else
            {
                return View(category);
            }
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _Categories.Delete(id);
            return Content("Delete done");
        }
        public IActionResult AddProductToCategories(int CategoryId)
        {
            CategoriesProduct categoryProduct = new CategoriesProduct()
            {
                CategoriesId = CategoryId
            };
            return View(categoryProduct);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCategories(CategoriesProduct categoryProduct , IFormFile file)
        {
            if (ModelState.IsValid)
            {
                await _Categories.AddProductToCategories(categoryProduct.CategoriesId,categoryProduct.Product,file);
                return Content("Add Product to Category Done :)");
            }
            else
            {
                return View(categoryProduct);
            }
        }
        public async Task<IActionResult> RemoveProductFromCategory(int CategoryId , int ProductId)
        {
            await _Categories.deleteProductFromCategories(CategoryId, ProductId );
            return Content("Delete done");
        }

    }
}
