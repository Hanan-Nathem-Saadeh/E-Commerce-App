
using FastMarket.Auth.Models.DTO;
using FastMarket.Auth.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FastMarket.Auth.Models.Services
{
    public class UserService : IUserService
    {
        
        private UserManager<ApplicationUser> _userManager;
  
        private SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInMngr)
        {
           
            _userManager = userManager;
            _signInManager = SignInMngr;
        }
        // implementation for the regester method
        public async Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                // Regester specific roles
               List<string> Roles = new List<string>();
             Roles.Add("Administrator");
              // Roles.Add("Editor");
               //Roles.Add("Users");
              await _userManager.AddToRolesAsync(user, Roles);

                //thanks for Regesteration(Sending Email to user After regester)

                SendGridClient client = new SendGridClient("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");
                SendGridMessage msg = new SendGridMessage();
                msg.SetFrom("22029820@student.ltuc.com");
                msg.AddTo(registerDto.Email);
                msg.SetSubject("Fast Market");
                msg.AddContent(MimeType.Html, "The Regesteration Done successfully ,thanks for using Fast Market ");
                await client.SendEmailAsync(msg);
                return new UserDto
                {
                    Username = user.UserName,
                };
            }
          // error list
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(registerDto.UserName) :
                    "";

                modelstate.AddModelError(errorKey, error.Description);
            }
            return null;

        }
        // implementation for the log in method

        public async Task<UserDto> Authenticate(string username, string password)
        {
            // check and map password and user name to log in
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                // if log in succeed then return the user name
                var user = await _userManager.FindByNameAsync(username);
                return new UserDto
                {
                    Username = user.UserName
                };
            }

            return null;
        }
        // method to get all users in our system
        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserDto
            {
                Username = user.UserName
            };
        }
        // logout from the site
        public async Task LogOut()
        {
             await _signInManager.SignOutAsync();
        }

        public async Task<List<ApplicationUser>> getAll()
        {
             return  await _userManager.Users.ToListAsync();
        }
    }
}
