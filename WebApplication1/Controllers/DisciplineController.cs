using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.DatabaseContext;

namespace WebApplication1.Controllers
{
    public class DisciplineController : Controller
    {
        private ApplicationContext _context;

        public DisciplineController()
        {
            _context = new ApplicationContext();
        }
        // GET
        [Authorize]
        public IActionResult Index()
        {
          
            var user=_context.UserDetails.Where(x => x.email == HttpContext.User.Identity.Name).FirstOrDefault();
            var valor = _context.DisciplineDetails
                .FromSqlRaw("SELECT d.key, d.name, d.course FROM \"Discipline\" d, \"DisciplineUser\" du " 
                            + "WHERE d.key = du.\"disciplineKey\" AND du.userkey =" + user.key + ";").ToList();
            
            return View(valor);
        }
    }
}