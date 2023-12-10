using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsInCSharp.KATA.Singleton_AdamAndEve
{
    public interface Human
    {
        string Name { get; set; }
        Female Mother { get; set; }
        Male Father { get; set; }
        public bool ValidateAdamOrEve(Human human)
        {
            if (human.Father == null || human.Mother == null)
            {
                if (human.Name != "Adam" && human.Name != "Eve")
                {
                    return false;
                }
            }
            return true;
        }
    }
}
