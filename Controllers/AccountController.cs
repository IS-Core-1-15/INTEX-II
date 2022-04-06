using INTEX_II.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace INTEX_II.Controllers
{
    public class AccountController : Controller
    {
        //controller for account management

        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        //set class properties
        public AccountController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            _userManager = um;
            _signInManager = sim;
        }

        //get route for login page
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        //post result for login page
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(loginModel.Username);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(loginModel);
        }

        //logout result
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();

            return Redirect(returnUrl);
        }
    }
}
