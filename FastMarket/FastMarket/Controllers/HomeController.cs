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

    }
}
