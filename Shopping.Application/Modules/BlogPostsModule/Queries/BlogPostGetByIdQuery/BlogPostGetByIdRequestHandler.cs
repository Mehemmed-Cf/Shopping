using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;

namespace Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetByIdQuery
{
    class BlogPostGetByIdRequestHandler : IRequestHandler<BlogPostGetByIdRequest, BlogPostGetByIdRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IActionContextAccessor ctx;
        private readonly ICategoryRepository categoryRepository;

        public BlogPostGetByIdRequestHandler(IBlogPostRepository blogPostRepository, IActionContextAccessor ctx, ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.ctx = ctx;
            this.categoryRepository = categoryRepository;
        }

        public async Task<BlogPostGetByIdRequestDto> Handle(BlogPostGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await blogPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var categorySet = await categoryRepository.GetAll(m => m.DeletedAt == null).ToDictionaryAsync(c => c.Id, cancellationToken);

            return new BlogPostGetByIdRequestDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                ImageUrl = $"{host}/uploads/images/{entity.ImagePath}",
                CategoryId = entity.CategoryId,
                CategoryName = categorySet.ContainsKey(entity.CategoryId) ? categorySet[entity.CategoryId].Name : null,
                Body = entity.Body,
                PublishedAt = entity.PublishedAt,
                PublishedBy = entity.PublishedBy,
            };
        }
    }
}
