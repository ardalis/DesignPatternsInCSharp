namespace DesignPatternsInCSharp.Singleton.v3
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
                if (_instance == null) // only get a lock if the instance is null
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
