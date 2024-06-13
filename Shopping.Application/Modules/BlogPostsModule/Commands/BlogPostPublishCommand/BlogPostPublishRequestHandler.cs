
using MediatR;
using Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostAddCommand;
using Shopping.Application.Repositories;

namespace Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostPublishCommand
{
    class BlogPostPublishRequestHandler : IRequestHandler<BlogPostPublishRequest, BlogPostPublishRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostPublishRequestHandler(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostPublishRequestDto> Handle(BlogPostPublishRequest request, CancellationToken cancellationToken)
        {
            var entity = await blogPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            var dto = new BlogPostPublishRequestDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                Body = entity.Body,
                ImageUrl = entity.ImagePath,
                PublishedAt = entity.PublishedAt,
                PublishedBy = entity.PublishedBy,
            };

            await blogPostRepository.SaveAsync(cancellationToken);

            return dto;
        }
    }
}
