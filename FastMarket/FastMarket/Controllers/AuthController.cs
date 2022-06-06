using FastMarket.Auth.Models.DTO;
using FastMarket.Auth.Models.Interfaces;
using FastMarket.Auth.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Controllers
{
    public class AuthController : Controller
    {
        private IUserService userService;

        public AuthController(IUserService userSer)
        {
            userService = userSer;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(RegisterDto register)
        {
            var user = await userService.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View();
        }

        public async Task<ActionResult<UserDto>> Authenticate(LoginDTO login)
        {
            var user = await userService.Authenticate(login.UserName, login.Password);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return Redirect("/");
        }
    }
}

