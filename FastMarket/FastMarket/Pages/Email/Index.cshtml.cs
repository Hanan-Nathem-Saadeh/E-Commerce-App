
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
using System.Threading.Tasks;
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
        public IndexModel(IConfiguration configration, IEmail email)
        {
            this._configration = configration;
            this._email = email;
        }
        public async void OnGet()
        {
            await _email.SendEmailAsync("f.man.x99@gmail.com", "test2", "hello");
        }
        public async Task OnPost(string toEmail, string title)
        {
            //string message = "Summary of my purchase : \n";
            //ListProduct = JsonConvert.DeserializeObject<List<Product>>
            //        (HttpContext.Request.Cookies["ProductObject"]);
            //if (ListProduct != null )
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
            //await _email.SendEmail(message, "f.man.x99@gmail.com", title);
            //// sales department message
            //await _email.SendEmail(message, "22029820@student.ltuc.com", title);
            //// User message
            //result = await _email.SendEmail(message, toEmail, title);
            //msg.SetFrom("22029820@student.ltuc.com", "Blog Admin");
            //msg.AddTo("f.man.x99@gmail.com");
            //msg.SetSubject("Hello from fast market project ... :)");
            //msg.AddContent(MimeType.Html, "Hello from fast market project ... :)");
            //var x=  await client.SendEmailAsync(msg).ConfigureAwait(false);
            //var xW = "SXAD";
            //if (x.IsSuccessStatusCode)
            //{
            //    ViewData["result"] = "true" ;
            //}
            //await _email.SendEmailAsync("fuadabuawad55@gmail.com", "adsda1", "hello" );
            // await _email.SendEmail(message, "f.man.x99@gmail.com", title);
            // var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient("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");
            //    var msg = new SendGridMessage()
            //    {
            //        From = new EmailAddress("22029820@student.ltuc.com", "DX Team"),
            //        Subject = "Sending with Twilio SendGrid is Fun",
            //        PlainTextContent = "and easy to do anywhere, even with C#",
            //        HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
            //    };
            //    msg.AddTo(new EmailAddress("eng.fadi.hb@gmail.com", "Test User"));
            //    var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            //var client = new SendGridClient("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");
            var from = new EmailAddress("22029820@student.ltuc.com");
            var subject = "Sending with Twilio SendGrid is Fun";
            var to = new EmailAddress("eng.fadi.hb@gmail.com");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}