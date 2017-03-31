using System;
using Business.Vocabulary;

namespace Examples.Vocabulary.CustomRules
{
    public class DiscountsDoNotApplyOnSundayRule : Business.Vocabulary.Rule<Order>
    {
        public DiscountsDoNotApplyOnSundayRule(Order ruleContext) : base(ruleContext, BusinessRuleGroup.DiscountPolicy)
        {
        }

        public override RuleResult Check()
        {
            bool ruleIsValid = true;
            if (Context.OrderDate != null)
            {
                ruleIsValid  = (Context.OrderDate.DayOfWeek == DayOfWeek.Sunday) && Context.DiscountPercent.Equals(0f);
                
            }
            return base.Check(ruleIsValid, "Discounts are not allowed on Sunday.");
        }
    }
}
