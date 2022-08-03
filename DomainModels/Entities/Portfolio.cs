using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Portfolio
    {
        public decimal TotalBalance { get; set; }//patrimônio da carteira somando todos os ativos
        public virtual ICollection<Product> Products { get; set; } //lista de produtos comprados
    }
}