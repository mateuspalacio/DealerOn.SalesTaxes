using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Taxes { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsImported { get; set; }
    }
}
