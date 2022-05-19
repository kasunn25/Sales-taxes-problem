using System;

namespace SalesTaxes.Domain.TaxCalculations
{
    public class TaxUtil
    {
        private static double TAX_ROUND_OFF = 0.05;

        public static double RoundOff(double value)
        {
            return (int)(value / TAX_ROUND_OFF + 0.5) * 0.05;
        }

        public static double Truncate(double value)
        {
            String result = value.ToString("N2"); ;
            return Double.Parse(result);
        }
    }
}
