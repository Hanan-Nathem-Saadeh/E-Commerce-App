using FastMarket.Data;
using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastMarket.Pages.CategPage
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProduct _Product;
        private readonly FastMarketDBContext _context;
        private readonly IConfiguration _configration;

        public ProductDetailsModel(IProduct product, FastMarketDBContext context, IConfiguration configration)
        {
            _Product = product;
            this._context = context;
            this._configration = configration;
        }
        [BindProperty]
        public int Count { get; set; }
        [BindProperty]
        public List<Product> ListProduct { get; set; }

        [BindProperty]
        public Product product { get; set; }
        public async Task OnGetAsync(int id)
        {
            product = await _Product.GetProduct(id);
        }
        public async Task<ActionResult> OnPostAsync (Product product,string userId)
        {


            //---------------
            if (!await _Product.checkAmount(product))
            {

                TempData["AlertMessage"] = "the number that you requer is out of range";

                return RedirectToPage("/CategPage/ProductDetails", new { id = product.Id });


             }
            
                if (HttpContext.Request.Cookies[$"ProductObject{userId}"] != null)
                {
                    ListProduct = JsonConvert.DeserializeObject<List<Product>>
                            (HttpContext.Request.Cookies[$"ProductObject{userId}"]);
                    //   ListProduct = new List<Product>();
                    ListProduct.Add(product);
                }
                else
                {
                    ListProduct.Add(product);

                }
                var JsonFile = JsonConvert.SerializeObject(ListProduct);

                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
                HttpContext.Response.Cookies.Append($"ProductObject{userId}", JsonFile, cookieOptions);
                // await OnGet(product.Id);

                TempData["AlertMessage"] = "An Item Added to the cart";

            return RedirectToPage("/CategPage/ProductDetails", new { id = product.Id });




        }

    }
}
