using FastMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastMarket.Pages.CartDetail
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int Count { get; set; }
        [BindProperty]
        public Product product { get; set; }
        [BindProperty]
        public List<Product> ListProduct { get; set; }

        [BindProperty]
        public decimal TotalPrice { get; set; }


        public void OnGet()
        {
            if (HttpContext.Request.Cookies["Count"] != null)
            {
                Count = int.Parse(HttpContext.Request.Cookies["Count"]);

                ListProduct = JsonConvert.DeserializeObject<List<Product>>
                        (HttpContext.Request.Cookies["ProductObject"]);
                foreach (Product item in ListProduct)
                {
                    // * Amount
                    TotalPrice += item.Price;
                }
            }
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies["ProductObject"]);
            ListProduct.Remove(ListProduct.Find(x=>x.Id ==id));
            var JsonFile = JsonConvert.SerializeObject(ListProduct);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Count", ListProduct.Count.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("ProductObject", JsonFile, cookieOptions);
            // await OnGet();

            // alert "item deleted"
            // Page();
            // RedirectToAction("Index");
            TempData["AlertMessage"] = "Item Deleted From the cart";
         //  Response.Redirect("/CartDetail/Index");
        return Redirect("/CartDetail/Index");
        }
    }
}