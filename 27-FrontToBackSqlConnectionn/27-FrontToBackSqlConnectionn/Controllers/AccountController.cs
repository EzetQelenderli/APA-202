using _27_FrontToBackSqlConnectionn.Models;
using _27_FrontToBackSqlConnectionn.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnectionn.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser>userManager)
        {
           _userManager = userManager;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid) return View();

            AppUser appUser = new()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName=registerVM.Username, 
                Email = registerVM.Email,
            };
            IdentityResult result=  await _userManager.CreateAsync(appUser,registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
            }
            return View(registerVM);
        }
    }
}
