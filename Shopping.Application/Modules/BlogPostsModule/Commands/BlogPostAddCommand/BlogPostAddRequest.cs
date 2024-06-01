using MediatR;
using Microsoft.AspNetCore.Http;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostAddCommand
{
    public class BlogPostAddRequest : IRequest<BlogPostAddRequestDto>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
    }
}
