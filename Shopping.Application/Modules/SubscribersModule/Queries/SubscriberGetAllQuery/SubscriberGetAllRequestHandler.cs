
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;

namespace Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetAllQuery
{
    class SubscriberGetAllRequestHandler : IRequestHandler<SubscriberGetAllRequest, IEnumerable<SubscriberRequestDto>>
    {
        private readonly ISubscriberRepository subscriberRepository;

        public SubscriberGetAllRequestHandler(ISubscriberRepository subscriberRepository)
        {
            this.subscriberRepository = subscriberRepository;
        }

        public async Task<IEnumerable<SubscriberRequestDto>> Handle(SubscriberGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = subscriberRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var response = await query.Select(m => new SubscriberRequestDto
            {
                Id = m.Id,
                Email = m.Email,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
