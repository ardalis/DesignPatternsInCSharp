using System;

namespace DesignPatternsInCSharp.RulesEngine.Discounts
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            if(customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return .05m;
            }
            return 0;
        }
    }
}
