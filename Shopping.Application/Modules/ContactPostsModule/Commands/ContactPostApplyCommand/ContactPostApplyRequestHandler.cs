using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.ContactPostsModule.Commands.ContactPostApplyCommand
{
    class ContactPostApplyRequestHandler : IRequestHandler<ContactPostApplyRequest>
    {
        private readonly IContactPostRepository contactPostRepository;

        public ContactPostApplyRequestHandler(IContactPostRepository contactPostRepository)
        {
            this.contactPostRepository = contactPostRepository;
        }

        public async Task Handle(ContactPostApplyRequest request, CancellationToken cancellationToken)
        {
            var entity = new ContactPost();
            entity.FullName = request.FullName;
            entity.Email = request.Email;
            entity.Subject = request.Subject;
            entity.Content = request.Content;
            entity.CreatedAt = DateTime.UtcNow;

            await contactPostRepository.AddAsync(entity, cancellationToken);
            await contactPostRepository.SaveAsync(cancellationToken);
        }
    }
}
