using FastMarket.Data;
using FastMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FastMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly FastMarketDBContext _cotext;

        public HomeController(FastMarketDBContext cotext)
        {
            _cotext = cotext;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult pruductsDetails(int id , string name ,string description ,int Amount ,decimal price)
        {
            Product product = new Product { Id = id, Name = name, Amount = Amount, Description = description, Price = price };
            return View(product);
        }

        public IActionResult CategoryDetails(int id, string name, string details)
        {

            Categories categories = new Categories { Id = id ,Name = name , Details = details };



            return View(categories);
        }
        public IActionResult CategoryList()
        {
            List<Categories> listCategories = new List<Categories>();
            listCategories.Add( new Categories { Id = 1, Name = "c1", Details = "c1 Details" });


            return View();
        }
        public IActionResult pruductsList()
        {
          List<Product> listProducts = new List<Product>();


        //    listProducts.Add(new Product { Id = 1, Name = "Product1", Amount = 30, Description = "Description1", Price = 100 });
        //    listProducts.Add(new Product { Id = 2, Name = "Product2", Amount = 40, Description = "Description2", Price = 350 });
        //    listProducts.Add(new Product { Id = 3, Name = "Product3", Amount = 50, Description = "Description3", Price = 200 });
        //    listProducts.Add(new Product { Id = 4, Name = "Product4", Amount = 60, Description = "Description4", Price = 230 });
        //    listProducts.Add(new Product { Id = 5, Name = "Product5", Amount = 70, Description = "Description5", Price = 105 });
            return View(listProducts);
        }

    }
}
