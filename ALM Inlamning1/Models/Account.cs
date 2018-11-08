using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Inlamning1.Models
{
    public class Account : Customer
    {
        public int AccountId { get; set; }
        public decimal Money { get; set; }
    }
}
