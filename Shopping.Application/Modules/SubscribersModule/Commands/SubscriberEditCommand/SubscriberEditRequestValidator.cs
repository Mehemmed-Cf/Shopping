using FluentValidation;

namespace Shopping.Application.Modules.SubscribersModule.Commands.SubscriberEditCommand
{
    internal class SubscriberEditRequestValidator : AbstractValidator<SubscriberEditRequest>
    {
        public SubscriberEditRequestValidator()
        {
            RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("");
        }
    }
}
