using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.DatabaseContext;

namespace WebApplication1.Controllers
{
    public class EnrollementController : Controller
    {
        private ApplicationContext _context;
        // GET

        public EnrollementController()
        {
            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            return View(_context.UserDetails.ToList());
        }

        [Authorize(Roles = "2,3")]
        public IActionResult ViewUser(int user)
        {
            ViewBag.DisciplineUser = _context.DisciplineUserDetails.FromSqlRaw(
                "SELECT \"DisciplineUser\".key ,\"disciplineKey\", userkey,name " +
                "FROM public.\"DisciplineUser\"INNER JOIN \"Discipline\" ON (\"disciplineKey\" = \"Discipline\".key)where \"userkey\"=" +
                user + ";").ToList();

            ViewBag.Discipline = _context.DisciplineDetails.ToList();

            TempData["userKey"] = user.ToString();

            return View("ViewUser", ViewBag);
        }

        [Authorize(Roles = "2,3")]
        public IActionResult Add(int disciplineKey, int userKey)
        {
            var old = _context.DisciplineUserDetails.Where(
                x => x.disciplineKey == disciplineKey && x.userkey == userKey).FirstOrDefault();
            if (old != null)
            {
                TempData["Message"] = "Failed";
                TempData["Title"] = "New Degree";
                TempData["Class"] = "alert-danger";
                ViewBag.DisciplineUser = _context.DisciplineUserDetails.FromSqlRaw(
                    "SELECT \"DisciplineUser\".key , \"disciplineKey\", userkey,name " +
                    "FROM public.\"DisciplineUser\"INNER JOIN \"Discipline\" ON (\"disciplineKey\" = \"Discipline\".key)where \"userkey\"=" +
                    userKey + ";").ToList();

                ViewBag.Discipline = _context.DisciplineDetails.ToList();
                return View("ViewUser", ViewBag);
            }

            _context.DisciplineUserDetails.Add(new DisciplineUser
            {
                userkey = userKey,
                disciplineKey = disciplineKey
            });
            _context.SaveChanges();


            TempData["Message"] = "Succesfully saved";
            TempData["Title"] = "New Degree";
            TempData["Class"] = "alert-success";
            TempData["userKey"] = userKey.ToString();
            ViewBag.DisciplineUser = _context.DisciplineUserDetails.FromSqlRaw(
                "SELECT \"DisciplineUser\".key , \"disciplineKey\", userkey,name " +
                "FROM public.\"DisciplineUser\"INNER JOIN \"Discipline\" ON (\"disciplineKey\" = \"Discipline\".key)where \"userkey\"=" +
                userKey + ";").ToList();

            ViewBag.Discipline = _context.DisciplineDetails.ToList();
            return View("ViewUser", ViewBag);
        }

        [Authorize(Roles = "2,3")]
        public IActionResult Delete(int key, int userKey)
        {
            if (key > 0)
            {
                var disciplineUser = _context.DisciplineUserDetails.Where(x => x.key == key).FirstOrDefault();
                if (disciplineUser != null)
                {
                    _context.DisciplineUserDetails.Remove(disciplineUser);
                    _context.SaveChanges();
                }
            }

            TempData["Message"] = "Succesfully deleted";

            TempData["Class"] = "alert-primary";

            TempData["Title"] = "New Degree";

            ViewBag.DisciplineUser = _context.DisciplineUserDetails.FromSqlRaw(
                "SELECT \"DisciplineUser\".key , \"disciplineKey\", userkey,name " +
                "FROM public.\"DisciplineUser\"INNER JOIN \"Discipline\" ON (\"disciplineKey\" = \"Discipline\".key)where \"userkey\"=" +
                userKey + ";").ToList();
            TempData["userKey"] = userKey.ToString();
            ViewBag.Discipline = _context.DisciplineDetails.ToList();
            return View("ViewUser", ViewBag);
        }
    }
}