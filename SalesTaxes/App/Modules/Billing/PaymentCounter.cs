using SalesTax.Domain.Common.Interfaces;
using SalesTax.TaxCalculations;
using SalesTaxes.App.Interface;
using SalesTaxes.App.Models;
using SalesTaxes.Infrastrutucture.Interfaces;
using System;
using System.Collections.Generic;

namespace SalesTax.Domain.Billing
{
    public class PaymentCounter : IPaymentCounter
    {
        private Biller biller;
        private Receipt receipt;
        private List<Product> productList;
        private string country = "Local";
        private ITaxRepository taxRepository;

        public PaymentCounter(ITaxRepository _taxRepository)
        {
            this.taxRepository = _taxRepository;
        }

        public void BillItemsInCart(IShoppingCart cart)
        {
            productList = cart.GetItemsFromCart();

            foreach (Product p in productList)
            {
                biller = GetBiller(country);
                double productTax = biller.CalculateTax(
                    p.Price, 
                    taxRepository.GetLocalTaxPercentage(p.Code),
                    p.Imported,
                    taxRepository.GetImportedTaxPercentage(p.Imported));
                double taxedCost = biller.CalcTotalProductCost(p.Price, productTax);
                p.TaxedCost = taxedCost;
            }
        }

        public Receipt GetReceipt()
        {
            double totalTax = biller.CalcTotalTax(productList);
            double totalAmount = biller.CalcTotalAmount(productList);
            receipt = biller.CreateNewReceipt(productList, totalTax, totalAmount);
            return receipt;
        }

        public void PrintReceipt(Receipt receipt)
        {
            biller.GenerateReceipt(receipt);
        }

        public Biller GetBiller(String strategy)
        {
            TaxCalculatorFactory factory = new TaxCalculatorFactory();
            ITaxCalculator taxCal = factory.GetTaxCalculator(strategy);
            return new Biller(taxCal);
        }

        public double GetProductTax(Product product)
        {
            biller = GetBiller(country);
            return biller.CalculateTax(
                product.Price, 
                taxRepository.GetLocalTaxPercentage(product.Code),
                product.Imported,
                taxRepository.GetImportedTaxPercentage(product.Imported));
        }

        public double GetProductTaxedCost(double price, double tax)
        {
            biller = GetBiller(country);
            return biller.CalcTotalProductCost(price, tax);
        }
    }
}
