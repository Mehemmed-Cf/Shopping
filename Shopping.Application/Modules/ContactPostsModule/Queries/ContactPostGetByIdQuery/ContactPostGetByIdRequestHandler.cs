using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.ContactPostsModule.Queries.ContactPostGetByIdQuery
{
    class ContactPostGetByIdRequestHandler : IRequestHandler<ContactPostGetByIdRequest, ContactPostRequestDto>
    {
        private readonly IContactPostRepository contactPostRepository;

        public ContactPostGetByIdRequestHandler(IContactPostRepository contactPostRepository)
        {
            this.contactPostRepository = contactPostRepository;
        }

        public async Task<ContactPostRequestDto> Handle(ContactPostGetByIdRequest request, CancellationToken cancellationToken)
        {
            ContactPost entity;

            if (request.OnlyAvailable)
            {
                entity = await contactPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            }
            else
            {
                entity = await contactPostRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            var dto = new ContactPostRequestDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Subject = entity.Subject,
                Content = entity.Content,
                Answer = entity.Answer,
                AnsweredAt = entity.AnsweredAt,
                AnsweredBy = entity.AnsweredBy,
                CreatedAt = entity.CreatedAt,
            };

            return dto;
        }
    }
}
