using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Learning.Utility;
using MVC_E_Learning.ViewModels;
using NuGet.Protocol.Plugins;

namespace MVC_E_Learning.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
		private readonly IUserRepository _iUser;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, 
                SignInManager<AppUser> signInManager, 
                IUserRepository iUser,
                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
			_iUser = iUser;
            _roleManager = roleManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.UserType == "Student")
                {

                    var user = new Student { UserName = model.Email, Email = model.Email, FirstName = model.FName, LastName = model.LName, Discriminator = model.UserType};
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        if (!await _userManager.IsInRoleAsync(user, "Student"))
                        {
                            await _userManager.AddToRoleAsync(user, "Student");
                        }
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Register", "Account");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    var user = new Instructor { UserName = model.Email, Email = model.Email, FirstName = model.FName, LastName = model.LName, Discriminator = model.UserType };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        if (!await _userManager.IsInRoleAsync(user, "Instructor"))
                        {
                            await _userManager.AddToRoleAsync(user, "Instructor");
                        }
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Register", "Account");

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return View(model);
				}
			}
			return View(model);
		}


        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


        public IActionResult ForgetPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var url = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);

                var email = new Email
                {
                    Recipient = model.Email,
                    Subject = "Reset Password",
                    Body = url
                };
                MailSettings.SendEmail(email);
                return RedirectToAction(nameof(CheckYourInbox));
            }
            ModelState.AddModelError("", "Email Doesn't Exist");
            return View();
        }

        public IActionResult CheckYourInbox()
        {
            return View();
        }



        public IActionResult ResetPassword(string email, string token)
        {
            TempData["Email"] = email;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var email = TempData["email"] as string;
            var token = TempData["token"] as string;

            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

                if (result.Succeeded) return RedirectToAction(nameof(Login));

                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);

            }
            return View(model);
        }
    }
}
