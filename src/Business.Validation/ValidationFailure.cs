//https://github.com/JeremySkinner/FluentValidation/blob/f6a54e9e4c42949c7bd60ff8b44b4db8dcb22cb7/src/FluentValidation/Results/ValidationFailure.cs

namespace Business.Validation
{

    public class ValidationFailure
    {
        /// <summary>
        /// Creates a new validation failure.
        /// </summary>
        public ValidationFailure(string propertyName, string error) : this(propertyName, error, null)
        {
        }

        /// <summary>
        /// Creates a new ValidationFailure.
        /// </summary>
        public ValidationFailure(string propertyName, string error, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
            AttemptedValue = attemptedValue;
        }

        /// <summary>
        /// The name of the property.
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// The error message
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// The property value that caused the failure.
        /// </summary>
        public object AttemptedValue { get; private set; }

        /// <summary>
        /// Custom state associated with the failure.
        /// </summary>
        public object CustomState { get; set; }

        /// <summary>
        /// Custom severity level associated with the failure.
        /// </summary>
        public Severity Severity { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the formatted message arguments.
        /// These are values for custom formatted message in validator resource files
        /// Same formatted message can be reused in UI and with same number of format placeholders
        /// Like "Value {0} that you entered should be {1}"
        /// </summary>
        public object[] FormattedMessageArguments { get; set; }

        /// <summary>
        /// The resource name used for building the message
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Creates a textual representation of the failure.
        /// </summary>
        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}