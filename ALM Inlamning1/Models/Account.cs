using System;
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
        [Range(0, Int32.MaxValue)]
        public decimal Money { get; set; }
    }
}
