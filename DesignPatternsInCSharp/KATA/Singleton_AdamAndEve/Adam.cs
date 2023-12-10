using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsInCSharp.KATA.Singleton_AdamAndEve
{
    public sealed class Adam : Male
    {
        private static readonly Adam singleAdam;
        static Adam()
        {
            singleAdam = new Adam("Adam");
        }
        private Adam(string name)
            : base(name, null, null)
        {
        }
        public static Adam GetInstance()
        {
            return singleAdam;
        }
    }
}
