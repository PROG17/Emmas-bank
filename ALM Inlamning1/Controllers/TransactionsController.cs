using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM_Inlamning1.Models;
using ALM_Inlamning1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ALM_Inlamning1.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly BankRepository _repo;
        List<Customer> customerList = new List<Customer>();

        public TransactionsController(BankRepository repo)
        {
            _repo = repo;
            customerList = _repo.Customers;
        }

        [HttpGet]
        public IActionResult Deposit(int value)
        {
            if (value == 2)
            {
                ViewBag.ErrorMessage = TempData["error"].ToString();
            }

            return View(customerList);
        }

        [HttpPost]
        public IActionResult Deposit(int number, int sum) //number, sum
        {

            foreach (var item in _repo.Accounts)   //Lägger till pengar i account som angivits
            {
                if (item.AccountId == number)
                {
                    item.Money += sum;
                    return RedirectToAction("Verify", new { number = number }); //För att slippa leta igenom och ta extra tid om den redan är summerad på
                }
            }

            return View(customerList);
        }

        [HttpPost]
        public IActionResult Withdraw(int number, int sum)
        {
            foreach (var items in _repo.Accounts)
            {
                if (items.AccountId == number)
                {
                    if (items.Money >= sum) //Om det finns den summan på kontot
                    {
                        items.Money -= sum;
                        return RedirectToAction("Verify", new { number = number }); //För att slippa leta igenom och ta extra tid om den redan är summerad på
                    }

                    else
                    {
                        TempData["error"] = "Du kan inte ta ut mer pengar än det som finns";
                        return RedirectToAction("Deposit", new {value = 2 });
                    }
                }
            }
            return RedirectToAction("Deposit");
        }

        public IActionResult Verify(int number)
        {
            var getValue = _repo.Accounts.Where(x => x.AccountId == number).FirstOrDefault();

            var person = _repo.Customers.Where(x => x.PersonId == getValue.PersonId).FirstOrDefault();

            //Snyggare i vyn om namnen finns med 
            getValue.Name = person.Name;
            getValue.LastName = person.LastName;

            return View(getValue);
        }
    }
}