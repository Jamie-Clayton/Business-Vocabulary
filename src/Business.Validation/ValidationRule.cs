using System.Collections.Generic;

namespace Business.Validation
{
    public abstract class ValidationRule<T>
    {
        abstract  public IEnumerable<ValidationFailure> Validate(T context);
    }
}