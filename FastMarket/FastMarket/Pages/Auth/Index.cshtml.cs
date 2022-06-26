using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMarket.Auth.Models;
using FastMarket.Auth.Models.DTO;
using FastMarket.Auth.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FastMarket.Pages.Auth
{
    public class IndexModel : PageModel
    {
        public readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }


        public RegisterDto registerDto { get; set; }
        public UserDto user { get; set; }


        public List<ApplicationUser> applicationUsers { get; set; }

        public async Task OnGet()
        {
            
        }

        
        public LoginDTO loginDTO{ get; set; }

        // Authenticate method to login
        public async Task<IActionResult> OnPostAsync(LoginDTO loginDTO)
        {

            user = await _userService.Authenticate(loginDTO.UserName, loginDTO.Password);

            if (user != null)
            {
                return   RedirectToPage("/Home/Index");
            }
            else
            {
                ViewData["WrongUser"]= "user name or password is wrong ";

                return null;
              }


        }
    }
}
