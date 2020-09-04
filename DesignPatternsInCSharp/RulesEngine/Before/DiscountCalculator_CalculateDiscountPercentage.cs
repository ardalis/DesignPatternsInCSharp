using System;
using Xunit;

namespace DesignPatternsInCSharp.RulesEngine.Before
{
    public class DiscountCalculator_CalculateDiscountPercentage
    {
        private DiscountCalculator _calculator = new DiscountCalculator();

        [Fact]
        public void Return15PctForNewCustomer()
        {
            var customer = new Customer();

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(0.15m, discount);
        }

        [Fact]
        public void Return10PctForVeteran()
        {
            var customer = new Customer() { IsVeteran = true, DateOfFirstPurchase = DateTime.Today.AddDays(-1) };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(0.1m, discount);
        }

        [Fact]
        public void Return5PctForSenior()
        {
            var customer = new Customer() { DateOfBirth = DateTime.Today.AddYears(-65).AddDays(-5), DateOfFirstPurchase = DateTime.Today.AddDays(-1) };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(0.05m, discount);
        }

        [Fact]
        public void Return10PctForBirthday()
        {
            var customer = new Customer()
            {
                DateOfBirth = DateTime.Today,
                DateOfFirstPurchase = DateTime.Today.AddDays(-1)
            };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(0.10m, discount);
        }

        [Fact]
        public void Return12PctFor5YearLoyalCustomer()
        {
            var customer = new Customer() { DateOfBirth = DateTime.Today.AddDays(-5), DateOfFirstPurchase = DateTime.Today.AddYears(-5) };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(0.12m, discount);
        }

        [Fact]
        public void Return22PctFor5YearLoyalCustomerOnBirthday()
        {
            var customer = new Customer() { DateOfBirth = DateTime.Today, DateOfFirstPurchase = DateTime.Today.AddYears(-5) };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.Equal(0.22m, discount);
        }

    }
}
