using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Vocabulary;

namespace Examples.CustomRules
{
    public class DiscountsDoNotApplyOnSundayRule : Business.Vocabulary.Rule<Order>
    {
        public DiscountsDoNotApplyOnSundayRule(Order ruleContext) : base(ruleContext, BusinessRuleGroup.DiscountPolicy)
        {
        }

        public override RuleResult Check()
        {
            bool ruleIsValid = (Context.OrderDate.DayOfWeek == DayOfWeek.Sunday) ? !Context.DiscountPercent.Equals(0f) : true;
            return base.Check(ruleIsValid, "Discounts are not allowed on Sunday.");
        }
    }
}
