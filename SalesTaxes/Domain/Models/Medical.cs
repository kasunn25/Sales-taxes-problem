using SalesTax.ProductFactories;
using System;

namespace SalesTaxes.App.Models
{
    public class Medical : Product
    {

        public Medical()
            : base()
        {

        }

        public Medical(string code, String name, double price, bool imported, int quantity)
            : base(code, name, price, imported, quantity)
        {
        }

        public override ProductFactory GetFactory()
        {
            return new MedicalProductFactory();
        }
    }
}
