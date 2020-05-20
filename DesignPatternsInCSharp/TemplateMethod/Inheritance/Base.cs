namespace DesignPatternsInCSharp.TemplateMethod.Inheritance
{
    public abstract class Base
    {
        private bool _importantSetting;
        public virtual void Do()
        {
            Initialize();
        }

        private void Initialize()
        {
            _importantSetting = true;
        }
    }

    public class Child : Base
    {
        public override void Do()
        {
            // do other stuff
        }
    }
}
