namespace DesignPatternsInCSharp.Singleton.v4
{
    // Source: https://csharpindepth.com/articles/singleton
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        // reading this will initialize the _instance
        public static readonly string GREETING = "Hi!";

        // Tell C# compiler not to mark type as beforefieldinit
        // (https://csharpindepth.com/articles/BeforeFieldInit)
        static Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
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
