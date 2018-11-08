using ALM_Inlamning1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Inlamning1.Repository
{
    public class BankRepository
    {
        public List<Customer> Customers = new List<Customer>();
        public List<Account> Accounts = new List<Account>();

        public BankRepository()
        {
            GetAccounts();
            GetCustomers();
        }

        public List<Customer> GetCustomers()
        {
            var person = new Customer
            {
                PersonId = 1,
                Name = "Emma",
                LastName = "Flensson",
                Account = Accounts.Where(x => x.PersonId == 1).ToList()
            };

            Customers.Add(person);

            person = new Customer
            {
                PersonId = 2,
                Name = "Jesper",
                LastName = "Grusan",
                Account = Accounts.Where(x => x.PersonId == 2).ToList()
            };

            Customers.Add(person);

            person = new Customer
            {
                PersonId = 3,
                Name = "Luna",
                LastName = "Vestin",
                Account = Accounts.Where(x => x.PersonId == 3).ToList()
            };

            Customers.Add(person);

            return Customers;
        }

        public List<Account> GetAccounts()
        {
            var account = new Account
            {
                AccountId = 2255,
                PersonId = 1,
                Money = 229993
            };

            Accounts.Add(account);

            account = new Account
            {
                AccountId = 2256,
                PersonId = 2,
                Money = 3322
            };

            Accounts.Add(account);

            account = new Account
            {
                AccountId = 2257,
                PersonId = 2,
                Money = 1200359
            };

            Accounts.Add(account);

            account = new Account
            {
                AccountId = 2258,
                PersonId = 3,
                Money = 600109
            };

            Accounts.Add(account);


            return Accounts;
        }

        public string Withdraw(int number, int sum)
        {
            var items = Accounts.Where(x => x.AccountId == number).FirstOrDefault();

            if (items == null)
            {
                return "NO EXISTING";
            }

            if (items.AccountId == number)
            {
                if (items.Money >= sum) //Om det finns den summan på kontot
                {
                    items.Money -= sum;
                    return "OK";
                }

                else
                {
                    return "ERROR";
                }
            }

            return "NO EXISTING";
        }

        public string Deposit(int number, int sum)
        {
            var item = Accounts.Where(x => x.AccountId == number).FirstOrDefault();   //Lägger till pengar i account som angivits

            if (item == null)
            {
                return "NO EXISTING";
            }

            if (item.AccountId == number)
            {
                item.Money += sum;
                return "OK";
            }

            return "NO EXISTING";
        }
    }
}
