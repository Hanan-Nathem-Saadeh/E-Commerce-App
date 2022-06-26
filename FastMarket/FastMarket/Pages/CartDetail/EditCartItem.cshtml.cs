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
        public void OnGet(int id)
        {

            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies["ProductObject"]);
            EditedProduct= ListProduct.Find(x => x.Id == id);


        }
        public async void OnPostAsync(int id)
        {
            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies["ProductObject"]);
            ListProduct.Remove(ListProduct.Find(x => x.Id == id));
            var JsonFile = JsonConvert.SerializeObject(ListProduct);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Count", ListProduct.Count.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("ProductObject", JsonFile, cookieOptions);
            // await OnGet();

            // alert "item deleted"
            Page();
        }

    }
}
