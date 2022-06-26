using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        // to get all Products

        public async Task<IActionResult> Index()
        {
            var ListProduct = await _Product.GetProducts();
            return View(ListProduct);
        }
        // to get specific product
        public async Task<IActionResult> Details(int id)
        {
            Product product = await _Product.GetProduct(id);

            return View(product);
        }


       [Authorize(Roles = "Administrator,Editor ")]
        //[Authorize(Roles = "Editor")]
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _Product.GetProduct(id);

            return View( product);
        }

        // to update the Product


        [HttpPost]
        public async Task<IActionResult> Update(Product product,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                await _Product.UpdateProduct(product.Id,product, file);
                return RedirectToAction("Index", "Product");
            }
            else
            {

                return View( product);
            }
        }
        [Authorize(Roles = "Administrator ")]

        public IActionResult addproductView()
        {
           // ViewBag.meth = "add";

            return View("addproductView");
        }

        // to Add new  Product

        [Authorize(Roles = "Administrator ")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                await _Product.Create(product,file);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                 return View("addproductView", product);
            }
        }

        // to Delete the Product

        [Authorize(Roles = "Administrator ")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _Product.Delete(id);


            return RedirectToAction("Index", "Product");
        }

    }
}
