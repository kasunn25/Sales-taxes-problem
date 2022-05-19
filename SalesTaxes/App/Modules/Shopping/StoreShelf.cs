using SalesTaxes.App.Interface;
using SalesTaxes.App.Models;
using System;
using System.Collections.Generic;

namespace SalesTax.Domain.Shopping
{
    public class StoreShelf : IStoreShelf
    {
        private readonly Dictionary<string, Product> productItems;

        public StoreShelf()
        {
            // hard coded inventry, only for evaluation purpose
            productItems = new Dictionary<string, Product>();
            AddProductItemsToShelf("book", new Book());
            AddProductItemsToShelf("music cd", new Miscellaneous());
            AddProductItemsToShelf("chocolate bar", new Food());
            AddProductItemsToShelf("box of chocolates", new Food());
            AddProductItemsToShelf("bottle of perfume", new Miscellaneous());
            AddProductItemsToShelf("packet of headache pills", new Medical());
        }

        public void AddProductItemsToShelf(String productItem, Product productCategory)
        {
            productItems.Add(productItem, productCategory);
        }

        public bool CheckProductAvailability(String name)
        {
            return productItems.ContainsKey(name.ToLower());
        }

        public Product SearchAndRetrieveItemFromShelf(string code, String name, double price, bool imported, int quantity)
        {
            Product productItem = productItems[name.ToLower()].GetFactory().CreateProduct(code, name, price, imported, quantity);
            return productItem;
        }

        public int GetShelfSize()
        {
            return productItems.Count;
        }
    }
}
