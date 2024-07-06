using MediatR;

namespace Shopping.Application.Modules.ContactPostsModule.Queries.ContactPostGetByIdQuery
{
    public class ContactPostGetByIdRequest : IRequest<ContactPostRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
