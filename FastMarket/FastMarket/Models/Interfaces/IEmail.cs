using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface IEmail
    {
        public Task<bool> SendEmail(string message, string toEmail, string title);
    }
}
