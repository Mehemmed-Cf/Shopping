using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetBySlugQuery
{
    class BlogPostGetBySlugRequestHandler : IRequestHandler<BlogPostGetBySlugRequest, BlogPostGetBySlugDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public BlogPostGetBySlugRequestHandler(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<BlogPostGetBySlugDto> Handle(BlogPostGetBySlugRequest request, CancellationToken cancellationToken)
        {
            var blogPostSet = blogPostRepository.GetAll();
            var categorySet = categoryRepository.GetAll();

            var joinedQuery = await (from bp in blogPostSet
                                     join c in categorySet on bp.CategoryId equals c.Id
                                     where bp.Slug == request.Slug
                                     select new BlogPostGetBySlugDto
                                     {
                                         Id = bp.Id,
                                         Title = bp.Title,
                                         Slug = bp.Slug,
                                         Body = bp.Body,
                                         ImagePath = bp.ImagePath,
                                         PublishedAt = bp.PublishedAt,
                                         PublishedBy = bp.PublishedBy,
                                         CategoryId = bp.CategoryId,
                                         CategoryName = c.Name
                                     }).FirstOrDefaultAsync(cancellationToken);

            return joinedQuery;
        }
    }
}
