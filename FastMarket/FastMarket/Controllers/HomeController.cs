using FastMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastMarket.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult CategoryList()
        {
            
            return View();
        } 
        public IActionResult CategoryDetails()
        {
            
            return View();
        }
        //public IActionResult Index()
        //{
            
        //    return View();
        //}
       // public 
        //Product product1 = new Product { Id = 1, Name = "Product1", Amount = 30, Description = "Description1", Price = 100 };
        //Product product2 = new Product { Id = 2, Name = "Product2", Amount = 40, Description = "Description2", Price = 350 };
        //Product product3 = new Product { Id = 3, Name = "Product3", Amount = 50, Description = "Description3", Price = 200 };
        //Product product4 = new Product { Id = 4, Name = "Product4", Amount = 60, Description = "Description4", Price = 230 };
        //Product product5 = new Product { Id = 5, Name = "Product5", Amount = 70, Description = "Description5", Price = 105 };
    }
}
