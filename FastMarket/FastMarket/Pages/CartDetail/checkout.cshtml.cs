using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FastMarket.Pages.CartDetail
{
    public class checkoutModel : PageModel
    {
        private readonly IOrder _order;
        private readonly IConfiguration _configration;
        private readonly IEmail _email;

        public checkoutModel(IOrder order, IConfiguration configration, IEmail email)
        {
            _order = order;
            this._configration = configration;
            this._email = email;
        }
        [BindProperty]
        public List<Product> ListProduct { get; set; }

        [BindProperty]
        public Product EditedProduct { get; set; }

        [BindProperty]
        public decimal TotalPrice { get; set; }


        [BindProperty]
        public Order order { get; set; }
        public void OnGet(string userId)
        {

            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies[$"ProductObject{userId}"]);
            foreach (Product item in ListProduct)
            {
                // * Amount
                TotalPrice += item.Price* item.Amount;
            }


        }
        public async void OnPostAsync(Order order, string userId)
        {
            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                      (HttpContext.Request.Cookies[$"ProductObject{userId}"]);

            ///add to database
          // await _order.Create(order);

            ///send emails
            //string message = "Summary of my purchase : \n";
            //ListProduct = JsonConvert.DeserializeObject<List<Product>>
            //        (HttpContext.Request.Cookies["ProductObject"]);
            //if (ListProduct != null)
            //{
            //    foreach (Product product in ListProduct)
            //    {
            //        //  < img src = "@product.ImageUri" width = 100 />
            //        message += $"Name :{product.Name} \n ";
            //        message += $" Description : {product.Description} \n ";
            //        message += $" Price : {product.Price} \n \n \n ";
            //    }
            //    message += $"this message for {toEmail} \n  Thanks To shopping from Fast Market... you are welcomed any time :)";
            //}
            //// warehouse  message
            //await _email.SendEmail(message, "f.man.x99@gmail.com", "FastMarket Order");
            //// sales department message
            //await _email.SendEmail(message, "22029820@student.ltuc.com", "FastMarket Order");
            //// User message
            // await _email.SendEmail(message, toEmail, "FastMarket Order");


            ///empty the cookie
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append($"ProductObject{userId}", "", cookieOptions);




            

        }
    }
}
