using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastMarket.Pages.CategPage
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProduct _Product;

        public ProductDetailsModel(IProduct product)
        {
            _Product = product;
        }
        [BindProperty]
        public int Count { get; set; }
        [BindProperty]
        public Product product { get; set; }
        [BindProperty]
        public IList<Product> ListProduct { get; set; }
        
        public async Task OnGetAsync(int id)
        {
            product = await _Product.GetProduct(id);
        }
        public async void OnPostAsync (Product product)
        {

            if (HttpContext.Request.Cookies["ProductObject"] != null)
            {
                ListProduct = JsonConvert.DeserializeObject<List<Product>>
                        (HttpContext.Request.Cookies["ProductObject"]);
                ListProduct.Add(product);
            }
            else
            {
                ListProduct.Add(product);
            }
            var JsonFile = JsonConvert.SerializeObject(ListProduct);

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Count", ListProduct.Count.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("ProductObject", JsonFile, cookieOptions);
            // await OnGet(product.Id);

            TempData["AlertMessage"] = "An Item Added to the cart";

            Page();
        }

    }
}
