using DealerOn.SalesTaxes.Business.OrderActions;
using DealerOn.SalesTaxes.Domain.Models;

namespace DealerOn.Tests
{
    public class ExtractProductsFromInputTests
    {
        ExtractProductsFromInput e = new();
        [Fact]
        public void ShouldReturnAReceipt()
        {
            // Arrange
            var input = new InputModel()
            {
                PurchasedProducts = new List<string>()
                {
                    "1 Book at 12.49",
                    "1 Imported box of chocolates at 10.00"
                }
            };
            // Act
            var resp = e.ExtractProductData(input);
            // Assert
            Assert.IsType<Receipt>(resp);
            Assert.NotNull(resp);
        }
    }
}