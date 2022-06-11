using DealerOn.SalesTaxes.Business.TaxCalculation;
using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Business.OrderActions
{
    public class ExtractProductsFromInput
    {
        // These objects are used to help achieving the output with separated Taxes. They basically call services.
        // If this was an API, this is where we would call the Repositories/Services, with Dependency Injection.
        CalculateTaxesForProduct taxes = new();
        CalculateTotalOrderPrice productPrices = new();
        public Receipt ExtractProductData(InputModel purchasedProducts) {
            // Creating a list of products that were purchased, so we can convert strings to Models that could be sent to a database, and are better for calculations.
            var products = new List<Product>();
            // Now we work with each input string
            foreach (var sub in purchasedProducts.PurchasedProducts) {
                // We split the string to assign it to object properties
                var details = sub.Split(' ');
                var prod = new Product();
                // this is to help with error checking inputs for quantity, since we convert it from string to Int
                int quantity = 0;
                int.TryParse(details[0], out quantity);
                if(quantity == 0) // if it's 0, we throw a null reference Exception
                {
                    throw new NullReferenceException("Quantity of products can't be null or 0, and must be an integer.");
                }
                prod.Quantity = quantity;
                for (int i = 1; i < details.Length - 1; i++) {
                    if (details[i] != "at") // we ignore the "at" from the input
                        if (string.IsNullOrEmpty(prod.Name)) // if the name has yet to be filled, we add only the string input
                            prod.Name += details[i];
                        else // if there's already a word on the name, we add a space and the second name
                            prod.Name += $" {details[i]}";
                }
                if (prod.Name.ToLower().Contains("imported")) // if it's imported we add a flag for it, for tax calculation
                    prod.IsImported = true;
                decimal price = 0;
                decimal.TryParse(details[details.Length - 1], out price);
                if(price == 0) // checking if there's a price inputed
                {
                    throw new NullReferenceException($"No price found for item {prod.Name}.");
                }
                prod.UnitPrice = price;
                if (products.Count > 0 && products.Any(i => i.Name == prod.Name)) { // here we are checking if any products from this sale equal the name of this current product
                    var index = products.FindIndex(i => i.Name == prod.Name); 
                    products[index].Quantity++; // if it's equal to another one, we just increment the quantity
                    products[index].TotalPrice = prod.UnitPrice * products[index].Quantity; // and change total price
                }
                else
                {
                    prod.TotalPrice = prod.UnitPrice;
                    products.Add(prod);
                }
            }
            decimal tax = 0; // now we calculate the taxes for the sale, since we have already finished getting the products
            foreach (Product product in products)
            {
                product.Taxes = taxes.CalculateTotalTaxes(product);
                product.TotalPrice += product.Taxes;
                tax += product.Taxes;
            }
            decimal totalProductPrices = productPrices.TotalProductsPrice(products); // Calculate total prices for the sale
            var receipt = new Receipt() // get the receipt
            {
                ProductsPurchased = products,
                SaleTaxes = tax,
                PriceTotal = totalProductPrices
            };
            return receipt;
        }
    }
}
