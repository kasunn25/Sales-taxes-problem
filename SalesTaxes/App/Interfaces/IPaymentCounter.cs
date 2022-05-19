using SalesTax.Domain.Billing;
using SalesTaxes.App.Models;
using System;

namespace SalesTaxes.App.Interface
{
    public interface IPaymentCounter
    {
        void BillItemsInCart(IShoppingCart cart);
        Receipt GetReceipt();
        void PrintReceipt(Receipt receipt);
        Biller GetBiller(String strategy);
        double GetProductTax(Product product);
        double GetProductTaxedCost(double price, double tax);
    }
}
