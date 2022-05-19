using SalesTax.ProductFactories;
using System;

namespace SalesTaxes.App.Models
{
    public class Miscellaneous : Product
    {
        public Miscellaneous()
            : base()
        {

        }

        public Miscellaneous(string code, String name, double price, bool imported, int quantity)
            : base(code, name, price, imported, quantity)
        {
        }

        public override ProductFactory GetFactory()
        {
            return new MiscellaneousProductFactory();
        }
    }
}
