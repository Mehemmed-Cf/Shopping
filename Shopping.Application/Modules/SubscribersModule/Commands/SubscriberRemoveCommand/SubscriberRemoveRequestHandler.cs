
using MediatR;
using Shopping.Application.Repositories;

namespace Shopping.Application.Modules.SubscribersModule.Commands.SubscriberRemoveCommand
{
    class SubscriberRemoveRequestHandler : IRequestHandler<SubscriberRemoveRequest>
    {
        private readonly ISubscriberRepository subscriberRepository;

        public SubscriberRemoveRequestHandler(ISubscriberRepository subscriberRepository)
        {
            this.subscriberRepository = subscriberRepository;
        }

        public async Task Handle(SubscriberRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await subscriberRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            subscriberRepository.Remove(entity);
            await subscriberRepository.SaveAsync(cancellationToken);
        }
    }
}
