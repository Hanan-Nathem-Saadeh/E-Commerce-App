using System.ComponentModel.DataAnnotations;

namespace FastMarket.Auth.Models.DTO
{
    public class RegisterDto
    {
        
        
            [Required(ErrorMessage = "You have missed to fill the username")]
            [Display(Name = "User Name")]
            [MinLength(3)]
            public string UserName { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            public string Email { get; set; }
        }
    }

