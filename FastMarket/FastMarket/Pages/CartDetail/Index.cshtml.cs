using FastMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace FastMarket.Pages.CartDetail
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int Count { get; set; }
        [BindProperty]
        public Product product { get; set; }
        [BindProperty]
        public Product deletedProduct { get; set; }
        [BindProperty]
        public IList<Product> ListProduct { get; set; }
        
        public void OnGet()
        {
            if (HttpContext.Request.Cookies["Count"] != null)
            {
                Count = int.Parse(HttpContext.Request.Cookies["Count"]);
                ListProduct = JsonConvert.DeserializeObject<List<Product>>
                        (HttpContext.Request.Cookies["ProductObject"]);
            }
        }
        public async void OnPostAsync()
        {
            ListProduct.Remove(deletedProduct);
            var JsonFile = JsonConvert.SerializeObject(ListProduct);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Count", ListProduct.Count.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("ProductObject", JsonFile, cookieOptions);
            // await OnGet(product.Id);
            Page();
        }
    }
}