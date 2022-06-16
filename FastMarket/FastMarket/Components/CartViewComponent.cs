using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastMarket.Components
{
    public class CartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           int CartCount=  int.Parse( HttpContext.Request.Cookies["Cart"]) ;
            return View(CartCount);
        }
       
    }
}
