using SalesTaxes.App.Models;

namespace SalesTax.ProductFactories
{
    public class MedicalProductFactory : ProductFactory
    {
        public override Product CreateProduct(string code, string name, double price, bool imported, int quantity)
        {
            return new Medical(code, name, price, imported, quantity);
        }
    }
}
