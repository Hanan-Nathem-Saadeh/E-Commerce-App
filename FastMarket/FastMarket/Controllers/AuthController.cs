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
            else
            {
                return View(register);

            }
           
        }

        public async Task<ActionResult<UserDto>> Authenticate(LoginDTO login)
        {
            var user = await userService.Authenticate(login.UserName, login.Password);
            if (user == null)
            {
                ViewBag.WrongUser = "user name or password is wrong !! ";
                return View("Index",login);

            }
            else
            {
                

                return View("Index", login);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await userService.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}

