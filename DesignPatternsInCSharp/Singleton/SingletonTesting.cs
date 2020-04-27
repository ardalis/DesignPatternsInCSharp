namespace DesignPatternsInCSharp.Singleton
{
    public class SingletonTesting
    {
        private readonly v6.Singleton _singleton;

        // Dependency Injection is OK
        public SingletonTesting(v6.Singleton singleton)
        {
            _singleton = singleton;
        }

        // Method argument is OK
        public void DoSomething1(v6.Singleton singleton)
        {
            // do something with the singleton instance
        }

        // Static access is problematic
        public void DoSomething2()
        {
            // Do some logic

            // This makes it very difficult to unit test this method
            // v6.Singleton.Instance.SaveToDatabase(data);

            // Do some other logic
        }
    }
}
