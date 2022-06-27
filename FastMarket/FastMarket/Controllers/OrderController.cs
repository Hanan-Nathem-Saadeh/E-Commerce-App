using Microsoft.AspNetCore.Mvc;

namespace FastMarket.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
