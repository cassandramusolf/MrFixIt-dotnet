using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.AspNetCore.Identity;
using MrFixIt.ViewModels;

namespace MrFixIt.Controllers
{
    public class AccountController : Controller
    {
        private MrFixItContext db = new MrFixItContext();


        //Basic User Account Info here...
        private readonly MrFixItContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MrFixItContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        //Check to see if user is logged in and return their information on the Index page if they are.
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var thisWorker = db.Workers.FirstOrDefault(item => item.UserName == User.Identity.Name);
                return View(thisWorker);
            }
            else
            {
                return View();
            }
        }

        //Return the Register view.
        public IActionResult Register()
        {
            return View();
        }

        //Register a new user with authentication and return to the index page if it was successful.
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        //Login page using Identity authentication - Go to Index page if login is successful
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //User logout
        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
