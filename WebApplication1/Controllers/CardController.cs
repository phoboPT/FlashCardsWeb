using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DatabaseContext;

namespace WebApplication1.Controllers
{
    public class CardController : Controller
    {
        private ApplicationContext _context;

        public CardController()
        {
            _context = new ApplicationContext();
        }
        // GET
        [Authorize]
        public IActionResult Index()
        {
            _context.UserDetails.Where(i => i.email == "1");
            return View(_context.CardDetails.ToList());
        }
    }
}