using System.Collections.Generic;
using System.Linq;

namespace Business.Vocabulary
{
    /// <summary>
    /// A collection of business rules that apply to a single business object, class, model or value.
    /// </summary>
    /// <typeparam name="T">Any object, class, model or value type to apply rules against.</typeparam>
    public class Rules<T> : List<Rule<T>>
    {
        /// <summary>
        /// Rules can belong to a group or subset of rules. We can validate or check rules for the smaller set of business rules.
        /// </summary>
        public string FilteredByGroup { get; private set; }
        List<RuleResult> checkList { get; set; }

        /// <summary>
        /// Checks all the rules that apply a single business object, class, model or value. Performs the same action as "Validate". 
        /// </summary>
        /// <param name="filterBy">We can validate or check rules for the smaller set of business rules.</param>
        /// <remarks>Unsure if Validate or Check rules is the best vocabulary choice. Check seems more business centric.</remarks>
        public void Check(string filterBy = "")
        {
            this.FilteredByGroup = filterBy;
            this.checkList = new List<RuleResult>();
            foreach (var ruleResult in this.Where(br => br.GroupName == filterBy))
            {
                checkList.Add(ruleResult.Check());
            }
        }

        /// <summary>
        /// Validates all the rules that apply a single business object, class, model or value. Performs the same action as "Check". 
        /// </summary>
        /// <param name="filterBy">We can validate or check rules for the smaller set of business rules.</param>
        /// <remarks>Unsure if Validate or Check rules is the best vocabulary choice. Validate seems more software centric.</remarks>
        public void Validate(string filterBy = "")
        {
            this.Check(filterBy);
        }

        /// <summary>
        /// List of all rules that are invalid and broken. Must call Check() or Validate() method prior.
        /// </summary>
        public List<RuleResult> Broken => checkList.Where(r => r.IsBroken).ToList();

        /// <summary>
        /// List of all rules that are valid. Must call Check() or Validate() method prior.
        /// </summary>
        public List<RuleResult> Valid => checkList.Where(r => !r.IsBroken).ToList();
    }
}
