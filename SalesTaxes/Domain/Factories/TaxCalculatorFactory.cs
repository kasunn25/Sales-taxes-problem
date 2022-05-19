using System;
using System.Collections.Generic;
using SalesTax.Domain.Common.Interfaces;
using SalesTax.Domain.TaxCalculations;

namespace SalesTax.TaxCalculations
{
    public class TaxCalculatorFactory
    {
        private Dictionary<String, ITaxCalculator> taxCalculators;

        public TaxCalculatorFactory()
        {
            taxCalculators = new Dictionary<String, ITaxCalculator>();
            RegisterInFactory("Local", new LocalTaxCalculator());
        }

        public void RegisterInFactory(string strategy, ITaxCalculator taxCalc)
        {
            taxCalculators.Add(strategy, taxCalc);
        }

        public ITaxCalculator GetTaxCalculator(String strategy)
        {
            ITaxCalculator taxCalc = (ITaxCalculator)taxCalculators[strategy];
            return taxCalc;
        }

        public int GetFactorySize()
        {
            return taxCalculators.Count;
        }
    }
}
