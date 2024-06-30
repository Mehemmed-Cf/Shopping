using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.SubscribersModule.Commands.SubscriberEditCommand
{
    class SubscriberEditRequestHandler : IRequestHandler<SubscriberEditRequest, Subscriber>
    {
        private readonly ISubscriberRepository subscriberRepository;

        public SubscriberEditRequestHandler(ISubscriberRepository subscriberRepository)
        {
            this.subscriberRepository = subscriberRepository;
        }

        public async Task<Subscriber> Handle(SubscriberEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await subscriberRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            entity.Email = request.Email;

            await subscriberRepository.EditAsync(entity);
            await subscriberRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
