using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FastMarket.Pages.CartDetail
{
    public class EditCartItemModel : PageModel
    {
        [BindProperty]
        public List<Product> ListProduct { get; set; }

        [BindProperty]
        public Product EditedProduct { get; set; }
        public void OnGet(int id,string userId)
        {



            if (userId == null)
            {
                return;
            }
           

            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies[$"ProductObject{ userId}"]);
            EditedProduct= ListProduct.Find(x => x.Id == id);


        }
        public async void OnPostAsync(Product editedProduct, int id, string userId)
        {
            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies[$"ProductObject{userId}"]);
             ListProduct.Find(x => x.Id == id).Amount=editedProduct.Amount;
            var JsonFile = JsonConvert.SerializeObject(ListProduct);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append($"ProductObject{userId}", JsonFile, cookieOptions);



            TempData["AlertMessage"] = $"Amount of product has be updated to {editedProduct.Amount}";


            // await OnGet();

            // alert "item deleted"
            // Page();
            // TempData["AlertMessage"] = "Item Deleted From the cart";
            //  Response.Redirect("/CartDetail/Index");
            //return Redirect("/CartDetail/Index");
        }

    }
}
