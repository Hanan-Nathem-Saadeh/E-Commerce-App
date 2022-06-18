using FastMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FastMarket.Pages.Settings
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public int Count { get; set; }
        [BindProperty]
        public Product product { get; set; }
        [BindProperty]
        public IList<Product> ListProduct { get; set; }       
        public void OnGet()
        {
            if (HttpContext.Request.Cookies["Count"] != null )
            {
                Count = int.Parse(HttpContext.Request.Cookies["Count"]);
                ListProduct = JsonConvert.DeserializeObject<List<Product>>
                        (HttpContext.Request.Cookies["ProductObject"]);
            }


        }
       
    }
}
