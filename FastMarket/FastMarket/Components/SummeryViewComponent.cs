using FastMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastMarket.Components
{
    public class SummeryViewComponent : ViewComponent
    {
        [BindProperty]
        public IList<Product> ListProduct { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies["ProductObject"]);   
            return View(ListProduct);
         
        }
    

    }
}
