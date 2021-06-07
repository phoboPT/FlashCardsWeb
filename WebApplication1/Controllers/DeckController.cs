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
        public IActionResult Index(int key, int discipline)
        {
            //TODO alterar id do user, disciplina tem de ser 0 por defeito ou alterar dinamicamente quando clicado na /Disciplina
             key = 2;
            var query = _context.DeckDetails.FromSqlRaw("SELECT de.* FROM \"Deck\" de, \"DisciplineUser\" du "
                + "WHERE  de.\"disciplineKey\"= du.disciplineKey AND du.userkey = " + key 
                + " AND (du.disciplineKey = " + discipline +" OR " + discipline + " = 0);").ToList();
            
            return View(query);
        }
    }
}