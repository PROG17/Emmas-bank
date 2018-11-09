﻿using ALM_Inlamning1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public string Withdraw(int number, string sum)
        {
            var check = Regex.IsMatch(sum.ToString(), @"[a-zA-Z]");

            if (check == false)
            {
                var replaceDecimal = sum.Replace(",", ".");

                var newSum = Convert.ToDecimal(replaceDecimal);

                var items = Accounts.Where(x => x.AccountId == number).FirstOrDefault();

                if (items == null)
                {
                    return "NO EXISTING";
                }

                if (items.AccountId == number)
                {
                    if (items.Money >= newSum) //Om det finns den summan på kontot
                    {
                        items.Money -= newSum;
                        return "OK";
                    }

                    else
                    {
                        return "ERROR";
                    }
                }
            }

            else
            {
                return "WRONG INPUT";
            }

            return "NO EXISTING";
        }

        public string Deposit(int number, string sum)
        {
            var check = Regex.IsMatch(sum, @"[a-zA-Z]");

            if (check == false)
            {
                var replaceDecimal = sum.ToString().Replace(",", ".");

                var newSum = Convert.ToDecimal(replaceDecimal);

                var item = Accounts.Where(x => x.AccountId == number).FirstOrDefault();   //Lägger till pengar i account som angivits

                if (item == null)
                {
                    return "NO EXISTING";
                }

                if (item.AccountId == number)
                {
                    item.Money += newSum;
                    return "OK";
                }

                return "NO EXISTING";
            }

            else return "WRONG INPUT";
        }
    }
}
