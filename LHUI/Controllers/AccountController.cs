using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBOL;
using LHUI.ViewModel;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LHUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        UserManager<LHUser> userManager;
        SignInManager<LHUser> signInManager;

        public AccountController(UserManager<LHUser> _userManager, SignInManager<LHUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                LHUser user = new LHUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var resultCreate = await userManager.CreateAsync(user, model.Password);
                var resultRoleAssign = await userManager.AddToRoleAsync(user, "Admin");

                var resultSign = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);

                //string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                //string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = confirmationToken }, protocol: HttpContext.Request.Scheme);
                ////EmailService.Send(user.Email, "Confirm your Email", "Click here to confirm your Email Address " + confirmationLink);
                //System.IO.File.WriteAllText(@"C:\Temp\ConfirmEmail.txt", confirmationLink);

                if (resultSign.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resultSign = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (resultSign.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}