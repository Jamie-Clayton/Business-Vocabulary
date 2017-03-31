using Business.Vocabulary;

namespace Examples.Vocabulary.CustomRules
{
    public class OrderRequiredInformationRule : Rule<Order>
    {
        public OrderRequiredInformationRule(Order ruleContext) : base(ruleContext, BusinessRuleGroup.OrderPolicy)
        {
        }

        public override RuleResult Check()
        {
            bool ruleIsValid = true;
            ruleIsValid = string.IsNullOrWhiteSpace(Context.CustomerName) && !Context.Total.Equals(0f);

            return base.Check(ruleIsValid, "The order is missing the following data: Customer Name, Order Total");
        }
    }
}
