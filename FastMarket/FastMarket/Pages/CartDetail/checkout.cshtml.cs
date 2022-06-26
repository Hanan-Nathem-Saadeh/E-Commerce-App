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
    public class checkoutModel : PageModel
    {
        [BindProperty]
        public List<Product> ListProduct { get; set; }

        [BindProperty]
        public Product EditedProduct { get; set; }

        [BindProperty]
        public decimal TotalPrice { get; set; }
        public void OnGet()
        {

            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies["ProductObject"]);
            foreach (Product item in ListProduct)
            {
                // * Amount
                TotalPrice += item.Price;
            }


        }
        public async void OnPostAsync()
        {
            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies["ProductObject"]);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Count", "0", cookieOptions);
            HttpContext.Response.Cookies.Append("ProductObject", null, cookieOptions);
            // await OnGet();

            // alert "item deleted"
            Page();
        }
    }
}
