using SalesTaxes.App.Models;
using System.Collections.Generic;

namespace SalesTaxes.App.Interface
{
    public interface IShoppingCart
    {
        void AddItemToCart(Product product);
        List<Product> GetItemsFromCart();
        int GetCartSize();
    }
}
