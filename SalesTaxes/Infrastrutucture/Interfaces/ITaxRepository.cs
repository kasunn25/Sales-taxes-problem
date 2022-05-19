using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Infrastrutucture.Interfaces
{
    public interface ITaxRepository
    {
        double GetLocalTaxPercentage(string code);
        double GetImportedTaxPercentage(bool isImported);
    }
}
