namespace Business.Vocabulary
{
    /// <summary>
    /// A single rule evaluated to pass (compliant) or fail (broken). Broken Rules should include a description of the reason the rule has failed to meet the businesses expectations.
    /// Rules generally belong to 2 types
    ///  1. Constraints or Action Assertions.
    ///  2. Derivations or tranformations. Rules that are based on transformed facts into other knowledge. E.g. Customer discount percent is within range for order size and the volume of previous orders.
    /// Rules can be defined in natural language using business vocabulary.
    /// Facts are not business rules. Eg. Customer can place an order.
    /// </summary>
    public class RuleResult
    {
        bool ruleVerified;

        /// <summary>
        /// Determines if a rule fails or is a broken business rule.
        /// </summary>
        public bool IsBroken
        {
            get { return !ruleVerified; }
            set { ruleVerified = !value; }
        }

        /// <summary>
        /// Determines if a rule passes and complies with the business rule.
        /// </summary>
        public bool IsValid
        {
            get { return ruleVerified; }
            set { ruleVerified = value; }
        }
        /// <summary>
        /// The description of the business rule that failed, explaing to the user why the rule failed and how to fix it.
        /// </summary>
        public string Description { get; set; }
    }
}
