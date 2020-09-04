using System;

namespace DesignPatternsInCSharp.RulesEngine.Before
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0;
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                // senior discount 5%
                discount = .05m;
            }
            if (customer.DateOfFirstPurchase.HasValue)
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
                {
                    // after 1 year, loyal customers get 10%
                    discount = Math.Max(discount, .10m);
                    if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                    {
                        // after 5 years, 12%
                        discount = Math.Max(discount, .12m);
                        if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                        {
                            // after 10 years, 20%
                            discount = Math.Max(discount, .2m);
                        }
                    }
                }
            }
            else
            {
                // first time purchase discount of 15%
                discount = Math.Max(discount, .15m);
            }
            if (customer.IsVeteran)
            {
                // veterans get 10%
                discount = Math.Max(discount, .10m);
            }

            return discount;
        }
    }
}
