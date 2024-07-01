using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;

namespace Shopping.Application.Modules.ContactPostsModule.Queries.ContactPostGetAllQuery
{
    class ContactPostGetAllRequestHandler : IRequestHandler<ContactPostGetAllRequest, IEnumerable<ContactPostRequestDto>>
    {
        private readonly IContactPostRepository contactPostRepository;

        public ContactPostGetAllRequestHandler(IContactPostRepository contactPostRepository)
        {
            this.contactPostRepository = contactPostRepository;
        }

        public async Task<IEnumerable<ContactPostRequestDto>> Handle(ContactPostGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = contactPostRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var response = await query.Select(m => new ContactPostRequestDto
            {
                Id = m.Id,
                FullName = m.FullName,
                Email = m.Email,
                Subject = m.Subject,
                Content = m.Content,
                Answer = m.Answer,
                AnsweredAt = m.AnsweredAt,
                AnsweredBy = m.AnsweredBy,
                CreatedAt = m.CreatedAt,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
