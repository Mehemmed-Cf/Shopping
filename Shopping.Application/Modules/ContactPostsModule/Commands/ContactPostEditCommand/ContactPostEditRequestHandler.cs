
using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.ContactPostsModule.Commands.ContactPostEditCommand
{
    class ContactPostEditRequestHandler : IRequestHandler<ContactPostEditRequest, ContactPost>
    {
        private readonly IContactPostRepository contactPostRepository;

        public ContactPostEditRequestHandler(IContactPostRepository contactPostRepository)
        {
            this.contactPostRepository = contactPostRepository;
        }

        public async Task<ContactPost> Handle(ContactPostEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await contactPostRepository.GetAsync(m => m.Id == request.Id, cancellationToken);

            //entity.FullName = request.FullName;
            //entity.Email = request.Email;
            //entity.Subject = request.Subject;
            //entity.Content = request.Content;
            entity.Answer = request.Answer;
            //entity.AnsweredAt = request.AnsweredAt;
            //entity.AnsweredBy = request.AnsweredBy;
            entity.AnsweredAt = DateTime.UtcNow;
            entity.AnsweredBy = 1;
            entity.CreatedAt = request.CreatedAt;


            await contactPostRepository.EditAsync(entity);
            await contactPostRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
