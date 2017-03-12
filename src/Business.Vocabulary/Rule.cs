namespace Business.Vocabulary
{
    /// <summary>
    /// Underlying structure of a single Business Rule.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>All business rules should inherit from this class. It's designed to be generic to allow objects/models/types to use the class to provide a patern for designing and checking businesses rule.</remarks>
    public abstract class Rule<T>
    {
        /// <summary>
        /// Underlying reference model/object/type that can be used by the rule to check some business logic.
        /// </summary>
        public T Context { get; }
        public string GroupName { get;}

        /// <summary>
        /// Each business rule is associated to contextual information like objects, classes, models, or value. 
        /// </summary>
        /// <param name="ruleContext">The contextual objects, classes, models or value we are going to apply rule against.</param>
        public Rule(T ruleContext, string ruleGroup = "")
        {
            this.Context = ruleContext;
            this.GroupName = ruleGroup;
        }

        /// <summary>
        /// Implement the business rule logic within this method.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Call the base.Check(successfulRuleLogic, description) </remarks>
        public abstract RuleResult Check();

        /// <summary>
        /// Internal method to help return the rules results. Call this from within your Business Rule implementation 'Check' method.
        /// </summary>
        /// <param name="ruleSuccess">Pass in the rule evaluation - true (passed) or false (failed/broken).</param>
        /// <param name="description">A description of why the rule failed (IsBroken).</param>
        /// <returns></returns>
        public RuleResult Check(bool ruleSuccess, string description)
        {
            RuleResult result = new RuleResult();
            result.IsBroken = !ruleSuccess;
            if (result.IsBroken) result.Description = description;
            return result;
        }
    }
}
