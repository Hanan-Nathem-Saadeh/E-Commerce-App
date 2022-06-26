
using FastMarket.Auth.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FastMarket.Auth.Models.Interfaces
{
    // this is an interface for the User Identity
    public interface IUserService
    {

        //Register Method
        public Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate);
        //login Method

        public Task<UserDto> Authenticate(string username, string password);
        // Get All users method
        public Task<UserDto> GetUser(ClaimsPrincipal principal);
        // logout method
        public Task LogOut();
        public Task<List<ApplicationUser>> getAll();


    }
}
