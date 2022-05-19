using SalesTaxes.App.Models;

namespace SalesTax.ProductFactories
{
    public class MiscellaneousProductFactory : ProductFactory
    {
        public override Product CreateProduct(string code, string name, double price, bool imported, int quantity)
        {
            return new Miscellaneous(code, name, price, imported, quantity);
        }
    }
}
