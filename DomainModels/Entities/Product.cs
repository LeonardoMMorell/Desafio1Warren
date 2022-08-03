using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Product
    {
        public int ProductId { get; set; } //id
        public string Symbol { get; set; } //nome do ativo
        public int Quotes { get; set; } //quantidade de cotas
        public decimal UnitPrice { get; set; } //preço de cada cota de um ativo
        public decimal NetValue { get; set; } //valor liquido total multiplicando Quotes pelo UnitPrice
        public DateTime ConvertedAt { get; set; } //data da compra
    }
}