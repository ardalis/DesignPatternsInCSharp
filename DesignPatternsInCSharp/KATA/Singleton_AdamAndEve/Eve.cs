using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesignPatternsInCSharp.KATA.Singleton_AdamAndEve
{
    public sealed class Eve : Female

    {
        private static readonly Eve singleEve;
        static Eve()
        {
            singleEve = new Eve("Eve");
        }
        private Eve(string name)
            : base(name, null, null)
        {
        }
        public static Eve GetInstance(Adam adam)
        {
            if (adam == null)
            {
                throw new ArgumentNullException();
            }
            return singleEve;
        }

    }
}
