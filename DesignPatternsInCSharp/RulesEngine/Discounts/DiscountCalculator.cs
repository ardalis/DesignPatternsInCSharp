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
            else
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                {
                    return .15m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                {
                    return .12m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                {
                    return .10m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2))
                {
                    return .08m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
                {
                    return .05m;
                }
            }

            if (customer.IsVeteran)
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
