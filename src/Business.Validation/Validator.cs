using System.Collections.Generic;
using System.Linq;

namespace Business.Validation
{
    class Validator<T>
    {
        readonly List<ValidationRule<T>> checklist = new List<ValidationRule<T>>();

        public void AddRule(ValidationRule<T> rule)
        {
            checklist.Add(rule);
        }

        IEnumerable<ValidationFailure> Validate(T context)
        {
            return checklist.SelectMany(r => r.Validate(context));         
        }

        
    }
}
