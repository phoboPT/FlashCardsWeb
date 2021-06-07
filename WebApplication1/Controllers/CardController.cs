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
        public IActionResult Index(int deck)
        {
            //TODO passar o deck desde o deckControler por parametros
            
            var query = _context.CardDetails.FromSqlRaw("SELECT * FROM \"Card\" " 
                    + "WHERE  activated = 1 AND deck = " + deck+ ";").ToList();
            
            return View(query);
            
        }
        
    }
}