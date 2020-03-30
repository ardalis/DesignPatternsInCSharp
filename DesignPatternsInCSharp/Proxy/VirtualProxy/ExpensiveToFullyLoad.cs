using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsInCSharp.Proxy.VirtualProxy
{
    public class VirtualExpensiveToFullyLoad : ExpensiveToFullyLoad
    {
        public override IEnumerable<ExpensiveEntity> AwayEntities 
        {
            get
            {
                if(base.AwayEntities == null)
                {
                    base.AwayEntities = new List<ExpensiveEntity>(ExpensiveDataSource.GetEntities(this));
                }
                return base.AwayEntities;
            }
            protected set => base.AwayEntities = value; 
        }

        public override IEnumerable<ExpensiveEntity> HomeEntities 
        {
            get
            {
                if (base.HomeEntities == null)
                {
                    base.HomeEntities = new List<ExpensiveEntity>(ExpensiveDataSource.GetEntities(this));
                }
                return base.HomeEntities;
            }
            protected set => base.HomeEntities = value;
        }
    }

    public class ExpensiveToFullyLoad
    {
        public static ExpensiveToFullyLoad Create()
        {
            return new VirtualExpensiveToFullyLoad();
        }

        public virtual IEnumerable<ExpensiveEntity> HomeEntities { get; protected set; }
        public virtual IEnumerable<ExpensiveEntity> AwayEntities { get; protected set; }
        
        public List<string> History { get; } = new List<string>();

        public ExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
        }
    }
}
