using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetByIdQuery
{
    class BlogPostGetByIdRequestHandler : IRequestHandler<BlogPostGetByIdRequest, BlogPostGetByIdRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IActionContextAccessor ctx;

        public BlogPostGetByIdRequestHandler(IBlogPostRepository blogPostRepository, IActionContextAccessor ctx)
        {
            this.blogPostRepository = blogPostRepository;
            this.ctx = ctx;
        }

        public async Task<BlogPostGetByIdRequestDto> Handle(BlogPostGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await blogPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            return new BlogPostGetByIdRequestDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                ImageUrl = $"{host}/uploads/images/{entity.ImagePath}",
                CategoryId = entity.CategoryId,
                CategoryName = "Demo",
                Body = entity.Body,
                PublishedAt = entity.PublishedAt
            };
        }
    }
}
