namespace DesignPatternsInCSharp.Singleton
{
    public class SingletonTesting
    {
        private readonly v6.Singleton _singleton;
        private readonly IServiceThatSingletonImplements _singleton2;

        // Dependency Injection is OK
        public SingletonTesting(v6.Singleton singleton)
        {
            _singleton = singleton;
        }

        // interface is even better
        public SingletonTesting(IServiceThatSingletonImplements singleton)
        {
            _singleton2 = singleton;
        }






        // Method argument is OK
        public void DoSomething1(v6.Singleton singleton)
        {
            // do something with the singleton instance
        }

        // Interface is better still
        public void DoSomething1(IServiceThatSingletonImplements singleton)
        {
            // do something with the singleton instance
        }







        // Static access is problematic
        public void DoSomething2()
        {
            // Do some logic

            // This makes it very difficult to unit test this method
            // This is an example of Static Cling code smell
            // See Refactoring for C# course
            // v6.Singleton.Instance.SaveToDatabase(data);

            // Do some other logic
        }
    }





    public interface IServiceThatSingletonImplements
    { }
}
