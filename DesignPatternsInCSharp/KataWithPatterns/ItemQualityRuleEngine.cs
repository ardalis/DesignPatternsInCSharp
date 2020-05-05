using System.Collections.Generic;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class ItemQualityRuleEngine
    {
        private List<RuleBase> _rules = new List<RuleBase>();
        public ItemQualityRuleEngine()
        {
            _rules.Add(new SulfurasRule());
            _rules.Add(new ConjuredItemRule());
            _rules.Add(new AgedBrieRule());
            _rules.Add(new BackstagePassesRule());
            _rules.Add(new NormalItemRule());
        }

        public void ApplyRules(ItemProxy item)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(item))
                {
                    rule.UpdateItem(item);
                    break;
                }
            }
        }
    }
}
