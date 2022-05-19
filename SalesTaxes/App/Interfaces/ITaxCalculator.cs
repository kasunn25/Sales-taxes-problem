using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Domain.Common.Interfaces
{
    public interface ITaxCalculator
    {
        double CalculateTax(double price, double localTax, bool isImported, double importedTax);
    }
}
