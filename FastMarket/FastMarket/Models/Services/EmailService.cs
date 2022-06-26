using FastMarket.Models.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace FastMarket.Models.Services
{

    public class EmailService : IEmail
    {

        //public  async Task<bool> SendEmail(string message, string toEmail,string title)
        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //   // var client = new SendGridClient("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");
        //   // var from = new EmailAddress("22029820@student.ltuc.com");
        //   //// 22029820@student.ltuc.com
        //   // var subject = subject;
        //   // var to = new EmailAddress(email);
        //   // var plainTextContent = htmlMessage;
        //   // var htmlContent = $"<strong>{htmlMessage}</strong>";
        //   // var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //   // var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        //   // return response.IsSuccessStatusCode;
        //}

         // this method to ability sending emails to department and users after regesteration and checkout

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient("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");
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("22029820@student.ltuc.com", "fuad");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);
            await client.SendEmailAsync(msg);
        }
    }

}

