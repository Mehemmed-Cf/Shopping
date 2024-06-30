using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByIdQuery
{
    class SubscriberGetByIdRequestHandler : IRequestHandler<SubscriberGetByIdRequest, SubscriberRequestDto>
    {
        private readonly ISubscriberRepository subscriberRepository;

        public SubscriberGetByIdRequestHandler(ISubscriberRepository subscriberRepository)
        {
            this.subscriberRepository = subscriberRepository;
        }

        public async Task<SubscriberRequestDto> Handle(SubscriberGetByIdRequest request, CancellationToken cancellationToken)
        {
            Subscriber entity;

            if (request.OnlyAvailable)
            {
                entity = await subscriberRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);
            }
            else
            {
                entity = await subscriberRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
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
