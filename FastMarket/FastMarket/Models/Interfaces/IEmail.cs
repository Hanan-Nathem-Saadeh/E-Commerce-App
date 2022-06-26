using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{    // this method to ability sending emails to department and users after regesteration and checkout
    public interface IEmail
    {
        //public Task<bool> SendEmail(string message, string toEmail, string title);
        public Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
