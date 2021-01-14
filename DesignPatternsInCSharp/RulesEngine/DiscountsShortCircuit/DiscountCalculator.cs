using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsInCSharp.RulesEngine.DiscountsShortCircuit
{
    // View History
    // https://github.githistory.xyz/ardalis/DesignPatternsInCSharp/blob/master/DesignPatternsInCSharp/RulesEngine/Discounts/DiscountCalculator.cs
    public interface IDiscountRule
    {
        decimal CalculateDiscount(Customer customer, decimal currentDiscount);
    }

    // Priority rules short-circuit all other rules if they match.
    public interface IExclusivePriorityRule : IDiscountRule
    {
        int PriorityLowestExecutesFirst { get; }
    }

    public class ReferredCustomerRule : IExclusivePriorityRule
    {
        public int PriorityLowestExecutesFirst => 0;

        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if(customer.Referrer != null)
            {
                // here we can either duplicate the logic in FirstTimeCustomerRule or use that rule
                bool firstTimeCustomer = new FirstTimeCustomerRule().CalculateDiscount(customer, 0) > 0;

                if (firstTimeCustomer) return .30m;
            }
            return 0;
        }
    }

    public class FirstTimeCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (!customer.DateOfFirstPurchase.HasValue)
            {
                return .15m;
            }
            return 0;
        }
    }

    public class LoyalCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfFirstPurchase.HasValue)
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
            return 0;
        }
    }

    public class VeteranRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.IsVeteran)
            {
                return .10m;
            }
            return 0;
        }
    }
    public class SeniorRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return .05m;
            }
            return 0;
        }
    }

    public class BirthdayRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            bool isBirthday = customer.DateOfBirth.HasValue && customer.DateOfBirth.Value.Month == DateTime.Today.Month && customer.DateOfBirth.Value.Day == DateTime.Today.Day;

            if (isBirthday) return currentDiscount + 0.10m;
            return currentDiscount;
        }
    }

    /// <summary>
    /// Adding exclusive priority rules we could just use a single list
    /// but then we would have LSP violations and we would need to sort it
    /// and treat the priority rules separately. Using two lists from the start
    /// yields a simpler overall design.
    /// </summary>
    public class DiscountRuleEngine
    {
        List<IDiscountRule> _rules = new List<IDiscountRule>();
        List<IExclusivePriorityRule> _priorityRules = new List<IExclusivePriorityRule>();

        public DiscountRuleEngine(IEnumerable<IDiscountRule> rules, IEnumerable<IExclusivePriorityRule> priorityRules)
        {
            _rules.AddRange(rules);
            _priorityRules.AddRange(priorityRules);
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0m;
            foreach(var priorityRule in _priorityRules.OrderBy(pr => pr.PriorityLowestExecutesFirst))
            {
                var result = priorityRule.CalculateDiscount(customer, 0);
                if (result > 0) return result;
            }
            foreach(var rule in _rules)
            {
                discount = Math.Max(discount, rule.CalculateDiscount(customer, discount));
            }
            return discount;
        }
    }

    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            // We need to produce separate list of priority rules now
            var ruleType = typeof(IDiscountRule);
            IEnumerable<IDiscountRule> rules = this.GetType().Assembly.GetTypes()
                .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                .Select(r => Activator.CreateInstance(r) as IDiscountRule);

            // create a strongly-typed list of just the priority rules
            var priorityRules = rules.Where(r => r is IExclusivePriorityRule)
                                     .Select(r => (IExclusivePriorityRule)r)
                                     .ToList();

            // create a list of all the other rules
            var baseRules = rules.Where(r => !(r is IExclusivePriorityRule)).ToList();

            var engine = new DiscountRuleEngine(baseRules, priorityRules);

            return engine.CalculateDiscountPercentage(customer);
        }
    }
}
