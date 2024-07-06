using MediatR;

namespace Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetAllQuery
{
    public class SubscriberGetAllRequest : IRequest<IEnumerable<SubscriberRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
