
using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostRemoveCommand
{
    class BlogPostRemoveRequestHandler : IRequestHandler<BlogPostRemoveRequest>
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostRemoveRequestHandler(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task Handle(BlogPostRemoveRequest request, CancellationToken cancellationToken)
        {
            BlogPost entity;

            if (request.OnlyAvailable)
            {
                entity = await blogPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            }
            else
            {
                entity = await blogPostRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            blogPostRepository.Remove(entity);
            await blogPostRepository.SaveAsync(cancellationToken);
        }
    }
}
