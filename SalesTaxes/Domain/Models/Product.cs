using SalesTax.ProductFactories;
using System;
using System.Linq;

namespace SalesTaxes.App.Models
{
    public abstract class Product
    {

        public string Code { get; set; }

        protected string Name { get; set; }

        private double _price;
        public double Price
        {
            set { _price = value; }
            get { return _price * Quantity; }
        }

        public bool Imported { get; set; }

        public int Quantity { get; set; }

        public double TaxedCost { get; set; }

        public Product()
        {
            this.Code = string.Empty;
            this.Name = string.Empty;
            this.Price = 0.0;
            this.Imported = false;
            this.Quantity = 0;
            this.TaxedCost = 0.0;
        }

        public Product(string code, String name, double price, bool imported, int quantity)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
            this.Imported = imported;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            return (Quantity + "\t\t" + ImportedToString(Imported) + ((Imported) ? "\t" : "\t\t") + GetFormattedName(Name) + "\t" + Price + "\t" + TaxedCost);
        }

        private string GetFormattedName(string name) 
        {
            String displayName = name;
            if (displayName.Length > 20)
            {
                displayName = displayName.Substring(0, 20) + "...";
            }
            else if (Enumerable.Range(0, 5).Contains(displayName.Length))
            {
                displayName += "\t\t";
            }
            else if (Enumerable.Range(0, 15).Contains(displayName.Length))
            {
                displayName += "\t";
            }

            return displayName;
        }

        public String ImportedToString(bool imported)
        {
            if (!imported)
                return "local";
            else
                return "imported";
        }

        public abstract ProductFactory GetFactory();
    }
}
