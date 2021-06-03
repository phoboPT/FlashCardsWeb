using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Models.DatabaseContext;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Help()
        {
            return View();
        }
       
        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username,string password,string returnUrl)
        {
            var users = _context.UserDetails.ToList();
            ViewData["ReturnUrl"] = returnUrl;
            var user=new User();
            foreach (var u in users)
            {
                if (u.email != username || u.password != password) continue;
                user = u;
                break;
            }

            Console.WriteLine(user.email);
            
            if (username == user.email && password ==user.password)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username",user.email));
                claims.Add(new Claim(ClaimTypes.Name,user.name));
                claims.Add(new Claim(ClaimTypes.NameIdentifier,user.name));
                claims.Add(new Claim(ClaimTypes.Role,user.type.ToString()));
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);

            }

            TempData["Error"] = "Error. Username or password is invalid.";
            return View("login");
        }
        [Authorize]
        public async Task< IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            
            return View("index");
        }
        [HttpGet("denied")]
        public  IActionResult Denied()
        {
           
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}