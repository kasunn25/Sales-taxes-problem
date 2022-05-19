using SalesTaxes.App;
using SalesTaxes.App.Interface;
using SalesTaxes.App.Models;
using Xunit;

namespace SalesTaxes.Tests
{
    public class SalesTaxes
    {
        private ISalesTaxesStore salesTaxesStore;

        public SalesTaxes() 
        {
            salesTaxesStore = new SalesTaxesStore();
        }

        [Fact]
        public void TaxCalculate_WhenBookProduct_Local_ReturnZero()
        {
            double expectedTax = 0;

            Product product = salesTaxesStore.RetrieveProduct("001", "book", 10.00, false, 1);
            var actualTax = salesTaxesStore.GetProductTax(product);

            Assert.Equal(expectedTax, actualTax);
        }

        [Fact]
        public void TaxCalculate_WhenBookProduct_Imported_ReturnFivePercent()
        {
            double expectedTax = 0.5;

            Product product = salesTaxesStore.RetrieveProduct("001", "book", 10.00, true, 1);
            var actualTax = salesTaxesStore.GetProductTax(product);

            Assert.Equal(expectedTax, actualTax);
        }

        [Fact]
        public void TaxCalculate_WhenFoodProduct_Local_ReturnZero()
        {
            double expectedTax = 0;

            Product product = salesTaxesStore.RetrieveProduct("002", "chocolate bar", 22.99, false, 1);
            var actualTax = salesTaxesStore.GetProductTax(product);

            Assert.Equal(expectedTax, actualTax);
        }

        [Fact]
        public void TaxCalculate_WhenFoodProduct_Imported_ReturnFivePercent()
        {
            double expectedTax = 1.15;

            Product product = salesTaxesStore.RetrieveProduct("002", "chocolate bar", 22.99, true, 1);
            double actualTax = salesTaxesStore.GetProductTax(product);

            Assert.Equal(expectedTax, actualTax, 2);
        }

        [Fact]
        public void TaxCalculate_WhenMedicalProduct_Local_ReturnZero()
        {
            double expectedTax = 0;

            Product product = salesTaxesStore.RetrieveProduct("003", "packet of headache pills", 23.99, false, 1);
            var actualTax = salesTaxesStore.GetProductTax(product);

            Assert.Equal(expectedTax, actualTax);
        }

        [Fact]
        public void TaxCalculate_WhenMedicalProduct_Imported_ReturnFivePercent()
        {
            double expectedTax = 1.20;

            Product product = salesTaxesStore.RetrieveProduct("003", "packet of headache pills", 23.99, true, 1);
            var actualTax = salesTaxesStore.GetProductTax(product);

            Assert.Equal(expectedTax, actualTax, 2);
        }

        [Fact]
        public void TaxCalculate_WhenMiscellaneousProduct_Local_ReturnTenPercent()
        {
            double expectedTax = 2.5;

            Product product = salesTaxesStore.RetrieveProduct("004", "bottle of perfume", 25.00, false, 1);
            var actualTax = salesTaxesStore.GetProductTax(product);

            Assert.Equal(expectedTax, actualTax);
        }

        [Fact]
        public void TaxCalculate_WhenMiscellaneousProduct_Imported_ReturnFifteenPercent()
        {
            double expectedTax = 3.75;

            Product product = salesTaxesStore.RetrieveProduct("004", "bottle of perfume", 25.00, true, 1);
            var actualTax = salesTaxesStore.GetProductTax(product);

            Assert.Equal(expectedTax, actualTax);
        }
    }
}
