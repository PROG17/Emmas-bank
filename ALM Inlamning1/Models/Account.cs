﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Inlamning1.Models
{
    public class Account : Customer
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Du kan bara skriva in siffror")]
        public decimal Money { get; set; }

        // Den här metoden sätter in pengar på ett konto
        internal void Deposit(decimal amount)
        {
            // Addera insatt belopp till saldot
            Money += amount;
        }

        // Den här metoden tar ut pengar från ett konto och skapar motsvarande transaktion
        internal void Withdrawal(decimal amount)
        {
            // Subtrahera uttaget belopp från saldot
            Money -= amount;
        }
    }
}
