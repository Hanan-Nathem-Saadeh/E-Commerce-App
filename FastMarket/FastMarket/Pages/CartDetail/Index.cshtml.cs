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


        [BindProperty]
        public decimal ItemTotalPrice { get; set; }
        public void OnGet(string userId)
        {
            Count = 0;


                if (userId == null)
                {
                return;
                }
            if (HttpContext.Request.Cookies[$"ProductObject{userId}"] != null)
            {
                ListProduct = JsonConvert.DeserializeObject<List<Product>>
                (HttpContext.Request.Cookies[$"ProductObject{userId}"]);
                if (ListProduct != null)
                {
                    foreach (Product item in ListProduct)
                    {
                        // Amount
                        TotalPrice += item.Price * item.Amount;
                    }

                    if (ListProduct.Count != 0)
                    {

                        Count = ListProduct.Count + 1;
                    }
                }
                
            }
            else
            {
                ListProduct = new List<Product>();
            }

                
              
            
        }
        public async Task<IActionResult> OnPostAsync(int id, string userId)
        {
            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies[$"ProductObject{userId}"]);
            ListProduct.Remove(ListProduct.Find(x=>x.Id ==id));
            var JsonFile = JsonConvert.SerializeObject(ListProduct);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append($"ProductObject{userId}", JsonFile, cookieOptions);


            TempData["AlertMessage"] = "Item Deleted From the cart";
         //  Response.Redirect("/CartDetail/Index");
        return Redirect($"/CartDetail/Index?userId={userId}");
        }
    }
}