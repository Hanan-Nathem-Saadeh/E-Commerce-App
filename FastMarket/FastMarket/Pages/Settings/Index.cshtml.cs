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
            if (HttpContext.Request.Cookies["Count"] != null)
            {
            Count = int.Parse( HttpContext.Request.Cookies["Count"]);
            ListProduct =JsonConvert.DeserializeObject<List<Product>>
                    (HttpContext.Request.Cookies["ProductObject"]);
           }

            
        }
        public void OnPost()
        {
            List<Product> MyList = new List<Product>();
            Product product= new Product { Id = 100, Name = "TestName1", Price = 15.5m, Description = "DescriptionTest", Amount = 150, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") };
            Product product2= new Product { Id = 101, Name = "TestName2", Price = 15.5m, Description = "DescriptionTest", Amount = 150, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") };
            Product product3= new Product { Id = 102, Name = "TestName3", Price = 15.5m, Description = "DescriptionTest", Amount = 150, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") };
            Product product4= new Product { Id = 103, Name = "TestName4", Price = 15.5m, Description = "DescriptionTest", Amount = 150, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") };
            MyList.Add(product);
            MyList.Add(product2);
            MyList.Add(product3);
            MyList.Add(product4);
            var JsonFile = JsonConvert.SerializeObject(MyList);



            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Count",MyList.Count.ToString(),cookieOptions);
          HttpContext.Response.Cookies.Append("ProductObject",JsonFile,cookieOptions);
        
            
        }

    }
}
