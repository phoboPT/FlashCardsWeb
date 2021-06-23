using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Authorize(Roles = "2,3")]
        public IActionResult Index()
        {
            return View(_context.DegreeDetails.ToList());
        }

        // GET

        [Authorize(Roles = "3")]
        public IActionResult DegreePage()

        {
            TempData["Title"] = "New Degree";
            return View();
        }

        [Authorize(Roles = "3")]
        [HttpPost("AddDegree")]
        public IActionResult AddDegree(string name, int grade)

        {
            _context.DegreeDetails.Add(new Degree
            {
                name = name,
                grade = grade
            });
            _context.SaveChanges();

            TempData["Class"] = "alert-success";
            TempData["Saved"] = "Succesfully saved";
            TempData["Title"] = "New Degree";
            return View("DegreePage");
        }

        [Authorize(Roles = "3")]
        [HttpPost("UpdateDegree")]
        public IActionResult UpdateDegree(string name, int grade, int key)

        {
            var degree = _context.DegreeDetails.Where(i => i.key == key).FirstOrDefault();
            if (!String.IsNullOrEmpty(name))
            {
                degree.name = name;
            }

            if (grade != null)
            {
                degree.grade = grade;
            }

            _context.Entry(degree).State = EntityState.Modified;

            _context.SaveChanges();

            TempData["Class"] = "alert-success";

            TempData["Message"] = "Succesfully updated";
            TempData["Title"] = "Edit Degree, " + name;
            return View("DegreePage");
        }

        [Authorize(Roles = "3")]
        public IActionResult EditDegree(int key)

        {
            var degree = _context.DegreeDetails.Where(i => i.key == key).FirstOrDefault();

            TempData["Class"] = "alert-success";

            TempData["Title"] = "Edit Degree, " + degree.name;
            return View("DegreePage", degree);
        }

        [Authorize(Roles = "3")]
        public ActionResult Delete(int key)
        {
            if (key > 0)
            {
                var degree = _context.DegreeDetails.Where(x => x.key == key).FirstOrDefault();
                if (degree != null)
                {
                    _context.DegreeDetails.Remove(degree);
                    _context.SaveChanges();
                }
            }

            TempData["Message"] = "Succesfully deleted";
            TempData["Class"] = "alert-primary";

            return View("Index", _context.DegreeDetails.ToList());
        }
    }
}