using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            
            
            return View(_context.DisciplineDetails.ToList());
        }
    }
}