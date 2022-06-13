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
    public class RegisterModel : PageModel
    {
        public readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }


        public string name2 { get; set; }
        public RegisterDto registerDto { get; set; }
        public UserDto user { get; set; }


        public List<ApplicationUser> applicationUsers { get; set; }

        public async Task OnGet()
        {

            applicationUsers = await _userService.getAll();

        }


        public async Task OnPostAsync(RegisterDto registerDto)
        {

            user = await _userService.Register(registerDto, this.ModelState);

            await OnGet();
        }
    }
}
