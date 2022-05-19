using SalesTaxes.App.Models;

namespace SalesTax.ProductFactories
{
    public class BookProductFactory : ProductFactory
    {
        public override Product CreateProduct(string code, string name, double price, bool imported, int quantity)
        {
            return new Book(code, name, price, imported, quantity);
        }
    }
}