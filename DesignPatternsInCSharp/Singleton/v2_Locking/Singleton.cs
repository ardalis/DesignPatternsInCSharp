namespace DesignPatternsInCSharp.Singleton.v2
{
    // Bad code
    // Source: https://csharpindepth.com/articles/singleton
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object padlock = new object();

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                lock (padlock) // this lock is used on *every* reference to Singleton
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
