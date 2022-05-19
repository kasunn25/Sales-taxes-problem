using SalesTaxes.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.App.Interface
{
    public interface ISalesTaxesStore
    {
        void RetrieveOrderAndPlaceInCart(string code, string name, double price, bool imported, int quantity);
        void GetSalesOrder(List<JsonProduct> inputProducts);
        void CheckOut();
        double GetProductTax(Product product);
        double GetProductTaxedCost(double price, double tax);
        Product RetrieveProduct(string code, string name, double price, bool imported, int quantity);
    }
}
