using FastMarket.Models.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace FastMarket.Models.Services
{
    public class EmailService : IEmail
    {

        public  async Task<bool> SendEmail(string message, string toEmail,string title)
        {

            var client = new SendGridClient("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");
            var from = new EmailAddress("22029820@student.ltuc.com");
            var subject = title;
            var to = new EmailAddress(toEmail);
            var plainTextContent = message;
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

    }
}
