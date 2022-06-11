using DealerOn.SalesTaxes.Business.TaxCalculation;
using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.Tests
{
    public class CalculateTaxesForProductTests
    {
        CalculateTaxesForProduct e = new CalculateTaxesForProduct();
        [Fact]
        public void ShouldCalculateTaxes()
        {
            // Arrange
            var prod = new Product()
            {
                Name = "Test Product",
                UnitPrice = 2,
                TotalPrice = 4,
                Quantity = 2,
                IsImported = false
            };
            // Act
            decimal taxes = e.CalculateTotalTaxes(prod);
            // Assert
            Assert.Equal((decimal)0.4, taxes);
        }
    }
}
