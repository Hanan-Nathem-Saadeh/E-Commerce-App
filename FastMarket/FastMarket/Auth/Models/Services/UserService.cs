
using FastMarket.Auth.Models.DTO;
using FastMarket.Auth.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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
                //List<string> Roles = new List<string>();
                ////Roles.Add("Administrator");
                ////Roles.Add("Editor");
                //Roles.Add("Users");
                //await _userManager.AddToRolesAsync(user, Roles);
                return new UserDto
                {
                    Username = user.UserName,
                };
            }
          
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

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new UserDto
                {
                    Username = user.UserName
                };
            }

            return null;
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserDto
            {
                Username = user.UserName
            };
        }
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
