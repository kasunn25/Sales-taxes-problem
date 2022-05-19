using SalesTaxes.App.Models;

namespace SalesTax.ProductFactories
{
    public class FoodProductFactory : ProductFactory
    {
        public override Product CreateProduct(string code, string name, double price, bool imported, int quantity)
        {
            return new Food(code, name, price, imported, quantity);
        }
    }
}
