namespace Business.Vocabulary.Common
{
    public class GreaterThanRule : Rule<int>
    {
        int ComparedTo { get; }
        string PropertyName { get; }

        public GreaterThanRule(int value, int comparedTo, string friendlyPropertyName) : base(value)
        {
            this.ComparedTo = comparedTo;
            this.PropertyName = friendlyPropertyName;
        }

        public override RuleResult Check()
        {
            bool ruleLogic = base.Context > this.ComparedTo;
            string description = $"{PropertyName}: {Context} must be greater than {ComparedTo}";
            return base.Check(ruleLogic, description);
        }
    }
}
