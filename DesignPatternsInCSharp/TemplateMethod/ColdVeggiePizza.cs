namespace DesignPatternsInCSharp.TemplateMethod
{
    public class ColdVeggiePizza : PanFood
    {
        public ColdVeggiePizza()
        {
            base.RequiresBaking = false;
        }
    }
}
