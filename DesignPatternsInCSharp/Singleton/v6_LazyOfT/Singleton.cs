using System;

namespace DesignPatternsInCSharp.Singleton.v6
{
    // Source: https://csharpindepth.com/articles/singleton
    public sealed class Singleton
    {
        // reading this will initialize the instance
        public static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                return _lazy.Value;
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
