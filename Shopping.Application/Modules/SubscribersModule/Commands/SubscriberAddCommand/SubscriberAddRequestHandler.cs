using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SubscribersModule.Commands.SubscriberAddCommand
{
    class SubscriberAddRequestHandler : IRequestHandler<SubscriberAddRequest, Subscriber>
    {
        private readonly ISubscriberRepository subscriberRepository;

        public SubscriberAddRequestHandler(ISubscriberRepository subscriberRepository)
        {
            this.subscriberRepository = subscriberRepository;
        }

        public async Task<Subscriber> Handle(SubscriberAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Subscriber
            {
               Email = request.Email,
            };

            await subscriberRepository.AddAsync(entity, cancellationToken);
            await subscriberRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
