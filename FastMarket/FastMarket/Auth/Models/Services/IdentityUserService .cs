
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Auth.Models.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
       // private JwtTokenService tokenService;
        
        public IdentityUserService(UserManager<ApplicationUser> userManager , JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            tokenService = jwtTokenService;
        }


        public async Task<UserDto> Register(RegisterUserDto registerDto, ModelStateDictionary modelstate)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                Gender = registerDto.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)   
            {
                List<string> Roles = new List<string>();
                //Roles.Add("DistrictManager");
                //Roles.Add("PropertyManager");
                Roles.Add("Agent");
                
                await _userManager.AddToRolesAsync(user, Roles);

                var userDto = new UserDto
                {
                    Username = user.UserName,
                    Id = user.Id,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromDays(15))

                };
                return userDto;
            }
            foreach (var error in result.Errors)
            {
             
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(registerDto.Username) :
                    "";

                modelstate.AddModelError(errorKey, error.Description);
            }
            return null;


        }
        public async Task<UserDto> Authenticate(string username, string password)
        { 
            var user = await _userManager.FindByNameAsync(username);
           
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    var userDto = new UserDto
                    {
                        Username = user.UserName,
                        Id = user.Id,
                        Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
                    };
                    return userDto;
                }}

            //return  (user and password not matching)
            return null;
        }

        //public async Task<UserDto> login(RegisterUserDto registerDto, ModelStateDictionary modelstate)
        //{
            
        //    return 
        //}

    }

}
