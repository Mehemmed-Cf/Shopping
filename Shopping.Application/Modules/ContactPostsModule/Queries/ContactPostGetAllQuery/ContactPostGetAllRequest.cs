using MediatR;

namespace Shopping.Application.Modules.ContactPostsModule.Queries.ContactPostGetAllQuery
{
    public class ContactPostGetAllRequest : IRequest<IEnumerable<ContactPostRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;  
    }
}
