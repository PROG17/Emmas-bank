using ALM_Inlamning1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Inlamning1.UnitTestData
{
    public class TransactionData
    {

        public bool WithdrawAmount(int number, int amount) //Inte kunna ta ut mer än det som finns
        {
            var listOfAccounts = GetAccounts().Where(x => x.AccountId == number).FirstOrDefault();

            if (listOfAccounts.Money >= amount)
            {
                listOfAccounts.Money = listOfAccounts.Money - amount;
            }

            if (listOfAccounts.Money == 4500 - amount)
            {
                return true;
            }

            return false;
        }

        public bool DepositMoney(int number, int amount) //Lägger in pengar
        {
            var listOfAccounts = GetAccounts().Where(x => x.AccountId == number).FirstOrDefault();

            if (amount > 0)
            {
                listOfAccounts.Money = listOfAccounts.Money + amount;
            }

            if (listOfAccounts.Money == 4500 + amount)
            {
                return true;
            }

            return false;
        }

        public List<Account> GetAccounts()
        {
            var listOfAccounts = new List<Account>();

            var account = new Account
            {
                AccountId = 1,
                Name = "Emma",
                LastName = "Davidsson",
                Money = 4500
            };

            listOfAccounts.Add(account);

            return listOfAccounts;
        }


        public string Verify(int number, int amount)
        {
            var listOfAccounts = GetAccounts().Where(x => x.AccountId == number).FirstOrDefault();

            if (listOfAccounts.Money >= amount)
            {
                return "Godkänt";
            }

            else
            {
                return "Nekad";
            }
        }
    }
}
