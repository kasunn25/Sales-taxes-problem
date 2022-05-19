using SalesTax.Domain.Common.Interfaces;
using SalesTaxes.Domain.TaxCalculations;

namespace SalesTax.Domain.TaxCalculations
{
    public class LocalTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double price, double localTax, bool isImported, double importedTax)
        {
            double tax = price * localTax;

            if (isImported)
                tax += (price * importedTax);

            //rounds off to nearest 0.05;
            tax = TaxUtil.RoundOff(tax);

            return tax;
        }
    }
}