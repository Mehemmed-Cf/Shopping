using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByEmailQuery
{
    class SubscriberGetByEmailRequestHandler : IRequestHandler<SubscriberGetByEmailRequest, SubscriberRequestDto>
    {
        private readonly ISubscriberRepository subscriberRepository;

        public SubscriberGetByEmailRequestHandler(ISubscriberRepository subscriberRepository)
        {
            this.subscriberRepository = subscriberRepository;
        }

        public async Task<SubscriberRequestDto> Handle(SubscriberGetByEmailRequest request, CancellationToken cancellationToken)
        {
            Subscriber entity;

            if (request.OnlyAvailable)
            {
                entity = await subscriberRepository.GetAsync(m => m.Email == request.Email && m.DeletedAt == null, cancellationToken);
            }
            else
            {
                entity = await subscriberRepository.GetAsync(m => m.Email == request.Email, cancellationToken);
            }

            var dto = new SubscriberRequestDto
            {
                Id = entity.Id,
                Email = entity.Email,
            };

            return dto;
        }
    }
}
