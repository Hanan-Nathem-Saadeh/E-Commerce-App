using FastMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastMarket.Components
{
    // this component (Cart) having count the elements in the cart
    //[ViewComponent(Name ="CartComponent")]
    public class CartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            //public IList<Product> ProductList = JsonConvert.DeserializeObject<Product>(cookie.Value);
            int Data = 0;
            int.TryParse(count.ToString(), out Data);
           
           // ViewComponentModel cartData = new ViewComponentModel { Count =int.Parse (HttpContext.Request.Cookies["Count"] ),ProductList=HttpContext.Request.Cookies["ProductObject"] };
            return View(Data);
        }   
             
    }
}
