using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;

namespace FastMarket.Pages.Email
{
    
    public class IndexModel : PageModel
    {
        
        [BindProperty]
        public string title { get; set; }  
        [BindProperty]
        public string ToEmail { get; set; }  
        [BindProperty]
        public bool result { get; set; }
        [BindProperty]
        public IList<Product> ListProduct { get; set; }
        private readonly IConfiguration _configration;
        private readonly IEmail _email;

        public IndexModel(IConfiguration configration,IEmail email)
        {

            this._configration = configration;
            this._email = email;
        }
        public async void OnGet()
        {
            
        }
        public async void OnPost( string toEmail, string title)
        {
            string message = "Summary of my purchase : \n";

            ListProduct = JsonConvert.DeserializeObject<List<Product>>
                    (HttpContext.Request.Cookies["ProductObject"]);
            foreach (Product product in ListProduct)
            {
              //  < img src = "@product.ImageUri" width = 100 />

               message +=  $"Name :{product.Name} \n ";
                message += $" Description : {product.Description} \n ";
                message += $" Price : {product.Price} \n \n \n ";

            }
            message += $"this message for {toEmail} \n  Thanks To shopping from Fast Market... you are welcomed any time :)";

            // warehouse  message
            await _email.SendEmail(message, "22029820@student.ltuc.com", title);
            // sales department message 
            await _email.SendEmail(message, "22029820@student.ltuc.com", title);
            // User message 
            result = await _email.SendEmail(message, toEmail, title);
            
            //SendGridClient client = new SendGridClient("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");
            //SendGridMessage msg = new SendGridMessage();

            //msg.SetFrom("22029820@student.ltuc.com", "Blog Admin");
            //msg.AddTo("22029806@student.ltuc.com");
            //msg.SetSubject("Hello from fast market project ... :)");
            //msg.AddContent(MimeType.Html, message);

            //await client.SendEmailAsync(msg);

           // var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
         }
        }
       
    }

