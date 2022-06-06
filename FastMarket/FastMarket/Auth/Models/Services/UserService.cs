
using FastMarket.Auth.Models.DTO;
using FastMarket.Auth.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
                // here goes the roles specifications ... 
                return new UserDto
                {
                    Username = user.UserName,
                };
            }
            // // Else, that means there is an error, let us collect all the errors using the modelState
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


        // Updated 
        public async Task<UserDto> Authenticate(string username, string password)
        {
            // replace the usage of the userManager and use the signinmanager
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            // get the user from the user manager after successfully operating login
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new UserDto
                {
                    Username = user.UserName
                };
            }

            //if (await _userManager.CheckPasswordAsync(user, password))
            //{

            //}

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
        //private UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _signInManager;


        //public IdentityUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInMngr)
        //{
        //    _userManager = userManager;
        //    _signInManager = SignInMngr;
        //}
        //public async Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = registerDto.UserName,
        //        Email = registerDto.Email
        //    };

        //    var result = await _userManager.CreateAsync(user, registerDto.Password);

        //    if (result.Succeeded)
        //    {
        //        return new UserDto
        //        {
        //            Username = user.UserName,
        //        };
        //    }
        //    foreach (var error in result.Errors)
        //    {
        //        var errorKey =
        //            error.Code.Contains("Password") ? "Password Issue" :
        //            error.Code.Contains("Email") ? "Email Issue" :
        //            error.Code.Contains("UserName") ? nameof(registerDto.UserName) :
        //            "";

        //        modelstate.AddModelError(errorKey, error.Description);
        //    }
        //    return null;

        //}

        //public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        //        {
        //    var user = await _userManager.GetUserAsync(principal);
        //    return new UserDto
        //    {
        //        Username = user.UserName
        //    };
        //}
        //public async Task<UserDto> Authenticate(string username, string password)
        //{
        // var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
        //    if (result.Succeeded)
        //    {
        //        var user = await _userManager.FindByNameAsync(username);
        //        return new UserDto
        //        {
        //            Username = user.UserName
        //        };
        //    }
        //    return null;
        //}
    }
}
