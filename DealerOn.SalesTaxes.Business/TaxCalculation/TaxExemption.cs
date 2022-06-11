using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Business.TaxCalculation
{
    public class TaxExemption
    {
        public TaxExemption()
        {

        }
        public List<string> TaxExemptTerms { get; } = new() // I decided to hard code some names related to food, books and medicine for tax exemption. 
        // In a real world scenario, this would likely come from a database, or a microservice that has the terms related to exemption.
        // Another thing that could be done, is add a Type to the Product Model, and specify it such as food or medicine when the user is giving the input.
        {
            "chocolate",
            "book",
            "pills",
            "chocolates",
            "pill",
            "medicine",
            "pizza",
            "hamburger",
            "burger",
            "steak"
        };
    }
}
