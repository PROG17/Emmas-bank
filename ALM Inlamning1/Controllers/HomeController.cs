using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALM_Inlamning1.Models;
using ALM_Inlamning1.Repository;

namespace ALM_Inlamning1.Controllers
{
    public class HomeController : Controller
    {
       private readonly BankRepository _repo;

        public HomeController(BankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            List<Customer> customerList = _repo.Customers;


            return View(customerList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
