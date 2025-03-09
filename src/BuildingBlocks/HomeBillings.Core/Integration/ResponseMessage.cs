using FluentValidation.Results;

namespace HomeBillings.Core.Integration
{
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }

        protected ResponseMessage() { }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
