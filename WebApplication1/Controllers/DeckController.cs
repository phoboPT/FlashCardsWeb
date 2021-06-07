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
        public IActionResult Index()
        {
            //TODO alterar id do user
            var id = 2;
            var query = _context.DeckDetails.FromSqlRaw("SELECT de.* FROM \"Deck\" de, \"DisciplineUser\" du "
                + "WHERE  de.\"disciplineKey\"= du.disciplineKey AND du.userkey = " + id+ ";").ToList();
            
            return View(query);
        }
    }
}