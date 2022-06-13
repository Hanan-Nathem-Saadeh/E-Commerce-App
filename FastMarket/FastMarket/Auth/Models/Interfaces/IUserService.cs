
using FastMarket.Auth.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FastMarket.Auth.Models.Interfaces
{
    public interface IUserService
    {


        public Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate);
        public Task<UserDto> Authenticate(string username, string password);
        public Task<UserDto> GetUser(ClaimsPrincipal principal);
        public Task LogOut();
        public Task<List<ApplicationUser>> getAll();


    }
}
