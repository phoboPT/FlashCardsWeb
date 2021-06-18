using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
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
        [Authorize(Roles = "2")]
        public IActionResult Index()
        {
            return View(_context.DegreeDetails.ToList());
        }

        // GET

        [Authorize(Roles = "2")]
        public IActionResult DegreePage()

        {
            TempData["Title"] = "New Degree";
            return View();
        }

        [Authorize(Roles = "2")]
        [HttpPost("AddDegree")]
        public IActionResult AddDegree(string name, int grade)

        {
            _context.DegreeDetails.Add(new Degree
            {
                name = name,
                grade = grade
            });
            _context.SaveChanges();


            TempData["Saved"] = "Succesfully saved";
            TempData["Title"] = "New Degree";
            return View("DegreePage");
        }
        
        [Authorize(Roles = "2")]
        [HttpPost("UpdateDegree")]
        public IActionResult UpdateDegree(string name, int grade,int key)

        {
            var degree = _context.DegreeDetails.Where(i => i.key == key).FirstOrDefault();
            _context.DegreeDetails.Update(new Degree
            {
                key=key,
                name = name,
                grade = grade
            });
            _context.SaveChanges();


            TempData["Saved"] = "Succesfully updated";
            TempData["Title"] = "Edit Degree, " + name;
            return View("DegreePage");
        }

        [Authorize(Roles = "2")]
        public IActionResult EditDegree(int key)

        {
            var degree = _context.DegreeDetails.Where(i => i.key == key).FirstOrDefault();


            TempData["Title"] = "Edit Degree, " + degree.name;
            return View("DegreePage", degree);
        }
        
        
    }
}