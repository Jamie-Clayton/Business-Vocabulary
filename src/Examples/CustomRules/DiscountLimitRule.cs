using Business.Vocabulary;

namespace Examples.CustomRules
{
    public class DiscountLimitRule : Rule<Order>
    {
        public DiscountLimitRule(Order ruleContext) : base(ruleContext, BusinessRuleGroup.DiscountPolicy)
        {
        }

        public override RuleResult Check()
        {
            bool ruleIsValid = true;
            string description = "";            
            if (Context.Total < 200 )
            {
                ruleIsValid = Context.DiscountPercent.Equals(0f);
                description = "Discounts cannot be applied to orders under $200.";
            }
                if (Context.Total > 200 & Context.Total <= 1000)
            {
                ruleIsValid = Context.DiscountPercent <= .05;
                description = $"Discount for order ${Context.Total} cannot be more than 5%";
            }
            if (Context.Total > 1000)
            {
                ruleIsValid = Context.DiscountPercent <= .2;
                description = $"Discount for order ${Context.Total} cannot be more than 20%";
            }
            
            return base.Check(ruleIsValid, description);
        }
    }
}
