using MediatR;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SubscribersModule.Commands.SubscriberAddCommand
{
    public class SubscriberAddRequest : IRequest<Subscriber>
    {
        public string Email { get; set; }
    }
}
