using SalesTaxes.App.Models;
using System;
using System.Collections.Generic;

namespace SalesTaxes.App.Interface
{
    public interface IStoreShelf
    {
        bool CheckProductAvailability(String name);
        void AddProductItemsToShelf(String productItem, Product productCategory);
        Product SearchAndRetrieveItemFromShelf(string code, String name, double price, bool imported, int quantity);
        int GetShelfSize();
    }
}
