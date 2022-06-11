using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Business
{
    public class Printer
    {
        public void Print(Receipt r) // print the receipt in the specified format
        {
            foreach (var item in r.ProductsPurchased)
            {
                string toPrint = "";
                toPrint += $"{item.Name}: {item.TotalPrice}";
                if (item.Quantity > 1)
                    toPrint += $" ({item.Quantity} @ {item.UnitPrice + (item.Taxes / item.Quantity)})";
                Console.WriteLine(toPrint);
            }
            Console.WriteLine($"Sales Taxes: {r.SaleTaxes}");
            Console.WriteLine($"Total: {r.PriceTotal}");
        }
    }
}
