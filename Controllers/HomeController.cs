using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Quotingdojo.Connectors;

namespace Quotingdojo.Controllers
{
    public class HomeController : Controller
    {
        //public DbConnector cnx;
        // public HomeController(){
        //     cnx = new DbConnector();

        // }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        [Route("quote")]
             public IActionResult Result(string Name, string Quote)
            {
                ViewBag.Name = Name;
                ViewBag.Quote = Quote;
                string query = $"INSERT INTO quotes (Name,Quote) VALUES ('{Name}','{Quote}')";
                DbConnector.Execute(query);
                 
                string query1 = "SELECT * FROM quotes";
                var allQuotes = DbConnector.Query(query1);
                ViewBag.allQuotes = allQuotes;
                return View("result");
            }
    }
}
