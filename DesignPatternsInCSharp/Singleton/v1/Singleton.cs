namespace DesignPatternsInCSharp.Singleton.v1
{
    public sealed class Singleton
    {
        private static Singleton _instance;

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                if(_instance == null)
                {
                    _instance = new Singleton();
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
