using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsInCSharp.Proxy.VirtualProxy
{
    public class LazyExpensiveToFullyLoad : BaseClassWithHistory
    {
        private Lazy<IEnumerable<ExpensiveEntity>> _homeEntities;
        public IEnumerable<ExpensiveEntity> HomeEntities { get { return _homeEntities.Value; } }

        private Lazy<IEnumerable<ExpensiveEntity>> _awayEntities;
        public IEnumerable<ExpensiveEntity> AwayEntities { get { return _awayEntities.Value; } }

        public LazyExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
            _homeEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities(this));
            _awayEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities(this));
        }
    }
}
