using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Inlamning1.Models
{
    public class Account : Person
    {
        public int AccountId { get; set; }
        public decimal Money { get; set; }

        public Account()
        {
        }

        public Account(int id, int personId, decimal money)
        {
            AccountId = id;
            PersonId = personId;
            Money = money;
        }
    }
}
