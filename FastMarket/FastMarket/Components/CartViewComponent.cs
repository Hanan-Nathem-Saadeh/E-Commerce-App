using FastMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastMarket.Components
{
    //[ViewComponent(Name ="CartComponent")]
    public class CartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //public IList<Product> ProductList = JsonConvert.DeserializeObject<Product>(cookie.Value);
            int Data = 0;
            int.TryParse(HttpContext.Request.Cookies["Count"], out Data);
           
           // ViewComponentModel cartData = new ViewComponentModel { Count =int.Parse (HttpContext.Request.Cookies["Count"] ),ProductList=HttpContext.Request.Cookies["ProductObject"] };
            return View(Data);
        }
    

    }
}
