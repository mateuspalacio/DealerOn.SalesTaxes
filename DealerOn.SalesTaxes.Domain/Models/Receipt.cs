using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Domain.Models
{
    public class Receipt
    {
        public IEnumerable<Product> ProductsPurchased { get; set; }
        public decimal SaleTaxes { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
