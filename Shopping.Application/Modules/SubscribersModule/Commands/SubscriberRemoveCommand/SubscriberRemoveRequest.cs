using MediatR;

namespace Shopping.Application.Modules.SubscribersModule.Commands.SubscriberRemoveCommand
{
    public class SubscriberRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
