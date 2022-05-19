using SalesTaxes.App.Models;
using System;
using System.Collections.Generic;

namespace SalesTax.Domain.Billing
{
    public class Receipt
    {
        private List<Product> ProductList { get; set; }
        private double TotalSalesTax { get; set; }
        private double TotalAmount { get; set; }

        public Receipt(List<Product> prod, double tax, double amount)
        {
            ProductList = prod;
            TotalSalesTax = tax;
            TotalAmount = amount;
        }

        public int GetTotalNumberOfItems()
        {
            return ProductList.Count;
        }

        public override string ToString()
        {
            String receipt = "";
            receipt += "****************************************************************************\n";
            receipt += "Your Billing details are below\n";
            receipt += "----------------------------- Date : " + DateTime.Now.ToString("dd/MM/yyyy") + " ----------------------------\n";
            receipt += "Quantity\tImported\tItem Name\t\tPrice\tTaxed Price\n";
            receipt += "----------------------------------------------------------------------------\n";
            foreach (var p in ProductList)
            {
                receipt += (p.ToString() + "\n");
            }
            receipt += "----------------------------------------------------------------------------\n";
            receipt += "Sales Taxes: " + TotalSalesTax + "\n";
            receipt += "Total: " + TotalAmount + "\n";
            receipt += "============================================================================\n";
            return receipt;
        }
    }
}
