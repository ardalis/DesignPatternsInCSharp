using System;

namespace DesignPatternsInCSharp.RulesEngine.DiscountsShortCircuit
{
    public class Customer
    {
        public DateTime? DateOfFirstPurchase { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsVeteran { get; set; }
        public ReferredBy Referrer { get; set; }
    }

    // Customers who are referred by others get a one time 30% discount on their first purchase.
    // We can determine if they are eligible by seeing if they have a referrer and if DateOfFirstPurchase is null.
    public class ReferredBy
    {
        public ReferredBy(Customer customer)
        {
            Customer = customer;
        }
        public Customer Customer { get; private set; }
        public DateTime DateReferred { get; set; } = DateTime.Today;
    }
}
