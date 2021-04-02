using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quotes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Quotes.Models.View_Model;

namespace Quotes.Controllers

{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IQuotesRepository _repository;
        private QuotesDbContext _context;


        public HomeController(ILogger<HomeController> logger, IQuotesRepository repository, QuotesDbContext context)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }

        public IActionResult Index()
        {
            //return the list of all the quotes
            return View( new QuoteList { Quotes = _context.Quotes });
        }
        [HttpGet]
        public IActionResult AddQuote()
        {
            //go to the addquote page on a get
            return View();
        }
        [HttpPost]
        public IActionResult AddQuote(QuoteByPeople quotes)
        {
            if(ModelState.IsValid)
            {
                // save movie to database


                _context.Quotes.Add(quotes);
                _context.SaveChanges();
               
                // go to Index page and save the new quote to the database
                return View("Index", new QuoteList { Quotes = _context.Quotes });
            }
            //if the data isnt valid stay on the same page
            else 
            { 
                 return View("AddQuote", quotes);
            }


        }
        public IActionResult Edit(int QId)
        {
            //return the edit page

            return View(new QuoteList { Quotes = _context.Quotes.Where( q => q.QId == QId ) });
        }
        public IActionResult SaveChanges(int QId, string QuotesNote, string AuthorFirst, string Citation, string Subject, DateTime Date, string AuthorLast)
        {
            //find which quote to change
            QuoteByPeople saying = _context.Quotes.Where(q => q.QId == QId).FirstOrDefault();

            //save changes
            saying.QuotesNote = QuotesNote;
            saying.AuthorFirst = AuthorFirst;
            saying.AuthorLast = AuthorLast;

            saying.QuotesNote = QuotesNote;
            saying.Citation = Citation;
            saying.Subject = Subject;
            saying.Date = Date;


            _context.SaveChanges();

            return Redirect("/Home/Index");
        }
        public IActionResult Delete(int QId)
        {
            //find where the id == the quote id you want to delete
            QuoteByPeople quote = _context.Quotes.Where(q => q.QId == QId).FirstOrDefault();
            //delete quote and save the changes
            _context.Remove(quote);
            _context.SaveChanges();

            return Redirect("/Home/Index");
        }

        public IActionResult Random()
        {
            
            return View(new QuoteList { Quotes = _context.Quotes.Where(q => q.QId == 2)});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
