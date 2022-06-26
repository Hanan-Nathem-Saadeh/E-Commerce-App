using FastMarket.Data;
using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        // to get all Categories
        public async Task<IActionResult> Index()
        {
            var list1 = await _Categories.GetCategories();

            return View(list1);
        }
        // to get specific Category
        public async Task<IActionResult> Details(int id)
        {
            var category = await _Categories.GetCategory(id);

            ViewBag.Title = id;

            return View(category);
        }

        [Authorize(Roles = "Administrator,Editor ")]
        public async Task<IActionResult> Edit(int id)
        {
            Categories category = await _Categories.GetCategory(id);
            return View(category);
        }
        // to update the Category

        [HttpPost]
        public async Task<IActionResult> Edit(Categories category)
        {     
            if (ModelState.IsValid)
            {
                Categories categories = await _Categories.UpdateCategories(category.Id, category);
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                    return View(category);
            }              
            
        }
        [Authorize(Roles = "Administrator ")]
        public IActionResult Add()
        {
             return View();
        }
        // to Add new  Category

        [HttpPost]
        public async Task<IActionResult> Add(Categories category)
        {
            if (ModelState.IsValid)
            {
               await _Categories.Create(category);
                ViewBag.ThankMessage = $"Add {category.Name} successfully :)  ";
                    return RedirectToAction("Index", "Categories");

            }
            else
            {
                return View(category);
            }
        }
        // to Delete the Category

        [Authorize(Roles = "Administrator ")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _Categories.Delete(id);
            return RedirectToAction("Index", "Categories");
        }


        [Authorize(Roles = "Administrator,Editor ")]
        public IActionResult AddProductToCategories(int CategoryId)
        {
            CategoriesProduct categoryProduct = new CategoriesProduct()
            {
                CategoriesId = CategoryId
            };
            return View(categoryProduct);
        }
        // To Add product to Category

        [HttpPost]
        public async Task<IActionResult> AddProductToCategories(CategoriesProduct categoryProduct , IFormFile file)
        {
            if (ModelState.IsValid)
            {
                await _Categories.AddProductToCategories(categoryProduct.CategoriesId,categoryProduct.Product,file);
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                return View(categoryProduct);
            }
        }
        // To remove product from Category

        //[Authorize(Roles = "Administrator ,Editor")]
        [Authorize(Roles = "Administrator,Editor ")]
        public async Task<IActionResult> RemoveProductFromCategory(int CategoryId , int ProductId)
        {
            await _Categories.deleteProductFromCategories(CategoryId, ProductId );
            return RedirectToAction("Index", "Categories");
        }

    }
}
