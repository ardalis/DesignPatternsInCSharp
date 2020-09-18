using System;

namespace DesignPatternsInCSharp.RulesEngine.Discounts
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            if(!customer.DateOfFirstPurchase.HasValue)
            {
                return .15m;
            }
           
            if(customer.IsVeteran)
            {
                return .10m;
            }

            if(customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return .05m;
            }

            return 0;
        }
    }
}
