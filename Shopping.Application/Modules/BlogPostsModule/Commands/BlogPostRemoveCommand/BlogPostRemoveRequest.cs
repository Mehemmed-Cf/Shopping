using MediatR;

namespace Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostRemoveCommand
{
    public class BlogPostRemoveRequest : IRequest
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public bool OnlyAvailable { get; set; } = true;

    }
}
