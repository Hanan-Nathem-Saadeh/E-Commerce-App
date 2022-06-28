using FastMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastMarket.Components
{
    // this component have the product list in the cart using cookies
    public class SummeryViewComponent : ViewComponent
    {
        [BindProperty]
        public List<Product> ListProduct { get; set; }
        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {




            if (userId == null)
            {
                return null;
            }
            if (HttpContext.Request.Cookies[$"ProductObject{userId}"] != null)
            {
                ListProduct = JsonConvert.DeserializeObject<List<Product>>
                (HttpContext.Request.Cookies[$"ProductObject{userId}"]);

              
            }
            else
            {
                ListProduct = new List<Product>();
            }





            return View(ListProduct);
         
        }
    

    }
}
