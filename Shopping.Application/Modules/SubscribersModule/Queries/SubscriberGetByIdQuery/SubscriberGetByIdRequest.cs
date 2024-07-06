using MediatR;

namespace Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByIdQuery
{
    public class SubscriberGetByIdRequest : IRequest<SubscriberRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
