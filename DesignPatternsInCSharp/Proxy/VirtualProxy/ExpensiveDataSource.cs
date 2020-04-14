using System.Collections.Generic;

namespace DesignPatternsInCSharp.Proxy.VirtualProxy
{
    public static class ExpensiveDataSource
    {
        public static List<ExpensiveEntity> GetEntities(BaseClassWithHistory owner)
        {
            var list = new List<ExpensiveEntity>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new ExpensiveEntity { Id = i });
            }
            owner.History.Add("Got expensive entities from source.");
            return list;
        }
    }
}
