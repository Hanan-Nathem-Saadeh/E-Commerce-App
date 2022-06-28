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

        // call regester service to sign up then if succeed go to home
        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(RegisterDto register)
        {
            var user = await userService.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                await userService.Authenticate(register.UserName,register.Password);
                return Redirect("/Home/Index");
                
            }
            else
            {
                return View(register);

            }
           
        }
        // call Authenticate service to login then if succeed go to home

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

                TempData["AlertMessage"] = $"Welcom {login.UserName} in Fast Market Website :)";

                return View("Index", login);
            }
            
        }
        // call LogOut service to LogOut then go to home

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await userService.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}

