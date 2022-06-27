using System.ComponentModel.DataAnnotations;

namespace FastMarket.Auth.Models.DTO
{
    //Dto for login
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
