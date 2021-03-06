using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DatabaseContext;

namespace WebApplication1.Controllers
{
    public class DeckController : Controller
    {
        private ApplicationContext _context;

        public DeckController()
        {
            _context = new ApplicationContext();
        }

        // GET
        [Authorize]
        public IActionResult Index(int discipline)
        {
            var user = _context.UserDetails.Where(x => x.email == HttpContext.User.Identity.Name).FirstOrDefault();

            string sql = "SELECT de.* FROM \"Deck\" de, \"DisciplineUser\" du "
                         + "WHERE  de.\"disciplineKey\"= du.\"disciplineKey\" AND du.userkey = " + user.key +
                         "AND (type = 1 OR (de.type = 0 AND de.\"userCreator\" = " + user.key + "))" +
                         " AND (de.\"disciplineKey\" = " + discipline + " OR " + discipline + " = 0);";

            var query = _context.DeckDetails.FromSqlRaw(sql).ToList();

            return View(query);
        }

        [Authorize]
        public IActionResult Edit(int deck)
        {
            var cards = _context.CardDetails.Where(x => x.deck == deck).ToList();


            return View(cards);
        }
    }
}