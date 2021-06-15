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
            Console.WriteLine(deck);
            var teste = TempData["ID"];
            if (teste == null)
            {
                TempData["ID"] = 0;
            }
            var query = _context.CardDetails.FromSqlRaw("SELECT * FROM \"Card\" "
                                                        + "WHERE  activated = 1 AND deck = " + deck + ";").ToList();

            return View(query);
        }

        [Authorize]
        [HttpPost("Cards")]
        public IActionResult Easy(int deck, int index)
        {
         TempData["ID"] = index+1;
            Console.WriteLine("entrou" + index);
            _context.UserCardAnswerDetails.Add(new UserCardAnswer
            {
                card = 1,
                user = 1,
                type = 1,
                date = DateTime.Now
            });
            _context.SaveChanges();
            Console.WriteLine("saiu");
            return RedirectToAction("Index",new {deck});
        }
    }
}