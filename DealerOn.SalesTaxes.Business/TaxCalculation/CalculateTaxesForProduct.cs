using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Business.TaxCalculation
{
    public class CalculateTaxesForProduct
    {
        TaxExemption t = new TaxExemption(); // to call the methods for verifying if an item is tax exempt
        public decimal CalculateTotalTaxes(Product product)
        {
            decimal taxes = 0;
            var notCaseSensitiveProdName = product.Name.ToLower(); // making it lower case to make sure there's a standard on the names
            var productName = new List<string>();
            productName = notCaseSensitiveProdName.Split(" ").ToList(); // splitting the word, so if there are multiple words on the product name we can identify which one might affect taxes. i.e.: chocolate, imported.
            bool isExempt = false;
            foreach (string c in productName) // if any of the names make it exempt from taxes we add a flag
            {
                if (t.TaxExemptTerms.Any(x => x.Contains(c)))
                {
                    isExempt = true;
                }
            }
            if (!isExempt) // if not exempt (food, books, medicine), we calculate the 10% taxes 
            {
                decimal toBeAdded = Math.Ceiling(product.UnitPrice * (decimal)0.1 * 20) / 20; // rounded to the next 5 cents
                taxes += (toBeAdded * product.Quantity);
            }
            if (product.IsImported) // if it's imported 
            {
                decimal toBeAdded = Math.Ceiling((product.UnitPrice) * (decimal)0.05 * 20) / 20; // 5 % tax
                taxes += (toBeAdded * product.Quantity);
            }
            return taxes = Math.Ceiling(taxes * 20) / 20; // return total taxes for a product
        }
    }
}
