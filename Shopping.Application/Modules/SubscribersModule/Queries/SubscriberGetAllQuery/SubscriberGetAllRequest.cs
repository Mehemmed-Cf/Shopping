using MediatR;

namespace Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetAllQuery
{
    internal class SubscriberGetAllRequest : IRequest<IEnumerable<SubscriberRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
