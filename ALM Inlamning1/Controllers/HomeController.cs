using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALM_Inlamning1.Models;

namespace ALM_Inlamning1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public List<Person> Peoples()
        {
            List<Person> persons = new List<Person>();

            var person = new Person
            {
                PersonId = 1,
                Name = "Emma",
                LastName = "Flensson"
            };
            persons.Add(person);

            person = new Person
            {
                PersonId = 2,
                Name = "Jesper",
                LastName = "Grusan"
            };

            persons.Add(person);

            person = new Person
            {
                PersonId = 3,
                Name = "Luna",
                LastName = "Vestin"
            };

            persons.Add(person);

            return persons;
        }



        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
