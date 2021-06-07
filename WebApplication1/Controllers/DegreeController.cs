using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DatabaseContext;

namespace WebApplication1.Controllers
{
    public class DegreeController : Controller
    { 
        
        private ApplicationContext _context;

        public DegreeController()
        {
            _context = new ApplicationContext();
        }
        // GET
        [Authorize(Roles="2")]
        public IActionResult Index()
        {
            
            
            return View(_context.DegreeDetails.ToList());
        }
    }
}