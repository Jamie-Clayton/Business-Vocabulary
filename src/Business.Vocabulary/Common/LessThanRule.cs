using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Vocabulary.Common
{
    public class LessThanRule : Rule<int>
    {
        int ComparedTo { get; }
        string PropertyName { get; }

        public LessThanRule(int value, int comparedTo, string friendlyPropertyName) : base(value)
        {
            this.ComparedTo = comparedTo;
            this.PropertyName = friendlyPropertyName;
        }

        public override RuleResult Check()
        {
            bool ruleLogic = base.Context < this.ComparedTo;
            string description = $"{PropertyName}: {Context} must be less than {ComparedTo}";
            return base.Check(ruleLogic, description);
        }
    }
}
