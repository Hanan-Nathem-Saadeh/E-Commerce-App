using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FastMarket.Pages.ProductPages
{
    public class IndexModel : PageModel
    {
        private readonly IProduct _product;

        public IndexModel(IProduct product)
        {
            _product = product;
        }
        [BindProperty]
        public List<Product> list1 { get; set; }
        public async Task OnGet()
        {
            list1 = await _product.GetProducts();
        }
    }
}
