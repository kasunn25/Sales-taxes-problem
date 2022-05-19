using SalesTax.Domain.Billing;
using SalesTax.Domain.Shopping;
using SalesTaxes.App.Interface;
using SalesTaxes.App.Models;
using SalesTaxes.Infrastrutucture.Interfaces;
using SalesTaxes.Infrastrutucture.Persistence.Repositories;
using System.Collections.Generic;

namespace SalesTaxes.App
{
    public class SalesTaxesStore 
        : ISalesTaxesStore
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IPaymentCounter paymentCounter;
        private readonly IStoreShelf storeShelf;

        /* 
         * Empty constructor is used by SalesTaxes.Tests project
         */
        public SalesTaxesStore() 
        {
            ITaxRepository taxRepository = new TaxRepository();

            shoppingCart = new ShoppingCart();
            paymentCounter = new PaymentCounter(taxRepository);
            storeShelf = new StoreShelf();
        }

        /* 
         * Console app is using this constructor via DI
         */
        public SalesTaxesStore(IShoppingCart _shoppingCart,
            IPaymentCounter _paymentCounter,
            IStoreShelf _storeShelf)
        {
            shoppingCart = _shoppingCart;
            paymentCounter = _paymentCounter;
            storeShelf = _storeShelf;
        }

        public void RetrieveOrderAndPlaceInCart(string code, string name, double price, bool imported, int quantity)
        {
            var product = storeShelf.SearchAndRetrieveItemFromShelf(code, name, price, imported, quantity);
            shoppingCart.AddItemToCart(product);
        }

        public Product RetrieveProduct(string code, string name, double price, bool imported, int quantity)
        {
            return storeShelf.SearchAndRetrieveItemFromShelf(code, name, price, imported, quantity);
        }

        public void GetSalesOrder(List<JsonProduct> inputProducts)
        {
            inputProducts.ForEach(product =>
            {
                bool imported = (product.imported.Equals("Y"));
                RetrieveOrderAndPlaceInCart(product.code, product.name, product.price, imported, product.quantity);
            });
        }

        public void CheckOut()
        {
            if (shoppingCart.GetCartSize() > 0)
            {
                paymentCounter.BillItemsInCart(shoppingCart);
                var receipt = paymentCounter.GetReceipt();
                paymentCounter.PrintReceipt(receipt);
            }
        }

        public double GetProductTax(Product product)
        {
            return paymentCounter.GetProductTax(product);
        }

        public double GetProductTaxedCost(double price, double tax)
        {
            return paymentCounter.GetProductTaxedCost(price, tax);
        }
    }
}
