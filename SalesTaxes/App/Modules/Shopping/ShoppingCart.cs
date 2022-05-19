using SalesTaxes.App.Interface;
using SalesTaxes.App.Models;
using System.Collections.Generic;

namespace SalesTax.Domain.Shopping
{
    public class ShoppingCart : IShoppingCart
    {
        private List<Product> productList { get; set; }

        public ShoppingCart()
        {
            productList = new List<Product>();
        }

        public void AddItemToCart(Product product)
        {
            productList.Add(product);
        }

        public List<Product> GetItemsFromCart()
        {
            return productList;
        }

        public int GetCartSize()
        {
            return productList.Count;
        }
    }
}
