using System.Security.Claims;
using System.Threading.Tasks;
using movierama.models;
using movierama.repositories;
using movierama.services;
using movierama.web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace movierama.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(): this(new UserService())
        {
            
        } 
            
        private AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
        // GET
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("account/login")]
        public async Task<IActionResult> Login(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.LoginUser(loginView.Email, loginView.Password);

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, $"{user.Id}-{user.FullName}"));
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Movies");
            }

            return View(loginView);
        }

        // GET
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [Route("account/register")]
        public IActionResult Register(RegisterView registerView)
        {
            if (ModelState.IsValid)
            {
                _userService.RegisterUser(
                    registerView.FirstName, registerView.LastName, registerView.EmailAddress, registerView.Password);
                return RedirectToAction("Index", "Movies");
            }

            return View(registerView);
        }
    }
}