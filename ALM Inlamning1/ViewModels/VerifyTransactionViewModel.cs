using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM_Inlamning1.Models;

namespace ALM_Inlamning1.ViewModels
{
    public class VerifyTransactionViewModel
    {
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
    }
}
