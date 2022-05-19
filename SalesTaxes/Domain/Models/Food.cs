using SalesTax.ProductFactories;
using System;

namespace SalesTaxes.App.Models
{
    public class Food : Product
    {
        public Food()
            : base()
        {

        }

        public Food(string code,String name, double price, bool imported, int quantity)
            : base(code, name, price, imported, quantity)
        {
        }

        public override ProductFactory GetFactory()
        {
            return new FoodProductFactory();
        }
    }
}
