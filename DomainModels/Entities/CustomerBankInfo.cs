using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class CustomerBankInfo
    {
        public string Account { get; set; } //código da conta
        public decimal AccountBalance { get; set; } //saldo
    }
}