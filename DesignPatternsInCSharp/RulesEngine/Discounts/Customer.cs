using System;

namespace DesignPatternsInCSharp.RulesEngine.Discounts
{
    public class Customer
    {
        public DateTime? DateOfFirstPurchase { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsVeteran { get; set; }
    }
}
