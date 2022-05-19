using SalesTaxes.Infrastrutucture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Infrastrutucture.Persistence.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        public double GetLocalTaxPercentage(string code)
        {
            switch (code)
            {
                case "001":
                    return 0.0;
                case "002":
                    return 0.0;
                case "003":
                    return 0.0;
                default:
                    return 0.10;
            }
        }

        public double GetImportedTaxPercentage(bool isImported)
        {
            return 0.05;
        }
    }
}
