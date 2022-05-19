using SalesTaxes.App.Models;
using System;

namespace SalesTax.ProductFactories
{
    public abstract class ProductFactory
    {
        public abstract Product CreateProduct(string code, String name, double price, bool imported, int quantity);
    }
}
