namespace DesignPatternsInCSharp.KataWithPatterns
{
    public abstract class RuleBase
    {
        public abstract bool IsMatch(ItemProxy item);
        public abstract void UpdateItem(ItemProxy item);
    }
}
