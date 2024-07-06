using FluentValidation;

namespace Shopping.Application.Modules.SubscribersModule.Commands.SubscriberAddCommand
{
    public class SubscriberAddRequestValidator : AbstractValidator<SubscriberAddRequest>
    {
        public SubscriberAddRequestValidator()
        {
            var availables = new string[] { "A", "B", "C", "D", "E" };

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .NotNull().WithMessage("Email cannot be null")
                .MinimumLength(2).WithMessage("Email must be at least 2 characters long");

            // Additional rules for other properties if needed
        }
    }
}
