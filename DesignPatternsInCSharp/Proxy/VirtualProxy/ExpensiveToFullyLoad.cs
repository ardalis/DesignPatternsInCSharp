using System.Collections.Generic;

namespace DesignPatternsInCSharp.Proxy.VirtualProxy
{
    public class ExpensiveToFullyLoad : BaseClassWithHistory
    {
        public static ExpensiveToFullyLoad Create()
        {
            return new VirtualExpensiveToFullyLoad();
        }

        public virtual IEnumerable<ExpensiveEntity> HomeEntities { get; protected set; }
        public virtual IEnumerable<ExpensiveEntity> AwayEntities { get; protected set; }
        
        protected ExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
        }
    }
}
