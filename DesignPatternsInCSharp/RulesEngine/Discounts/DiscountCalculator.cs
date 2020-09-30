using System;

namespace DesignPatternsInCSharp.RulesEngine.Discounts
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            bool isBirthday = customer.DateOfBirth.HasValue && customer.DateOfBirth.Value.Month == DateTime.Today.Month && customer.DateOfBirth.Value.Day == DateTime.Today.Day;
            if (!customer.DateOfFirstPurchase.HasValue)
            {
                return .15m;
            }
            else
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                {
                    if (isBirthday) return .25m;
                    return .15m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                {
                    if (isBirthday) return .22m;
                    return .12m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                {
                    if (isBirthday) return .20m;
                    return .10m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2) &&
                    !customer.IsVeteran)
                {
                    if (isBirthday) return .18m;
                    return .08m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1) &&
                    !customer.IsVeteran)
                {
                    if (isBirthday) return .15m;
                    return .05m;
                }
            }

            if (customer.IsVeteran)
            {
                if (isBirthday) return .20m;
                return .10m;
            }

            if(customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                if (isBirthday) return .15m;
                return .05m;
            }

            if (isBirthday) return .10m;

            return 0;
        }
    }
}
