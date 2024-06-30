using MediatR;

namespace Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByEmailQuery
{
    public class SubscriberGetByEmailRequest : IRequest<SubscriberRequestDto>
    {
        public string Email { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
