using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Business.OrderActions
{
    public class CalculateTotalOrderPrice
    {
        public decimal TotalProductsPrice(List<Product> products) { // for each product we calculate the total price
            decimal totalPrice = 0;
            foreach (Product product in products) {
                totalPrice += product.TotalPrice;
            }
            return totalPrice;
        }
    }
}
