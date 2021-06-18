using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using WebApplication1.Models;
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
            var user = _context.UserDetails.Where(x => x.email == HttpContext.User.Identity.Name).FirstOrDefault();
            const string date = "2021-06-01";

            var teste = TempData["ID"];
            if (teste == null)
            {
                TempData["ID"] = 0;
            }

            string sql = " SELECT c2.* FROM ( " +
                         " SELECT c.key from \"Card\" c WHERE c.deck =" + deck + "EXCEPT " +
                         " SELECT DISTINCT v.key FROM ( " +
                         " SELECT cd.* FROM  \"Card\" cd, \"UserCardAnswer\" uc WHERE cd.key= uc.card " +
                         " AND cd.activated = 1 AND cd.deck = " + deck + " AND uc.user= " + user.key +
                         " AND uc.date >= '" + date + "'" +
                         " ORDER BY date ASC, type DESC) v ) v2, \"Card\" c2 WHERE v2.key = c2.key;";

            var query = _context.CardDetails.FromSqlRaw(sql).ToList();

            if (query.Count > 0)
            {
                return View(query);
            }

            var sql2 = "SELECT DISTINCT v.card, c.* FROM ( " +
                       " SELECT uc.* FROM  \"Card\" cd, \"UserCardAnswer\" uc WHERE cd.key= uc.card " +
                       " AND cd.activated = 1 AND cd.deck = " + deck + " AND uc.user= " + user.key +
                       " AND uc.date >= '" + date + "'" +
                       " ORDER BY date ASC, type DESC) v, \"Card\" c WHERE c.key = v.card;";

            var query2 = _context.CardDetails.FromSqlRaw(sql2).ToList();

            return View(query2);
        }

        [Authorize]
        [HttpPost("Cards")]
        public IActionResult Easy(int deck, int index,int card,string response)
        {
            var user = _context.UserDetails.Where(x => x.email == HttpContext.User.Identity.Name).FirstOrDefault();
            TempData["ID"] = index + 1;

            _context.UserCardAnswerDetails.Add(new UserCardAnswer
            {
                card =card,
                user = user.key,
                type = 1,
                date = DateTime.Now
            });
            _context.SaveChanges();

            return RedirectToAction("Index", new {deck});
        }
    }
}