using MediatR;
using Shopping.Application.Repositories;
using Shopping.Application.Services.File;
using Shopping.Domain.Models.Entities;
using Shopping.Infrastructure.Abstracts;
using Shopping.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostAddCommand
{
    class BlogPostAddRequestHandler : IRequestHandler<BlogPostAddRequest, BlogPostAddRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostAddRequestHandler(IBlogPostRepository blogPostRepository, IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }

        public async Task<BlogPostAddRequestDto> Handle(BlogPostAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new BlogPost
            {
                Title = request.Title,
                Slug = request.Title.ToSlug(),
                CategoryId = request.CategoryId,
                Body = request.Body,
                PublishedAt = DateTime.Now,
                PublishedBy = 1,
            };

            entity.ImagePath = await fileService.UploadAsync(request.Image);

            await blogPostRepository.AddAsync(entity, cancellationToken);
            await blogPostRepository.SaveAsync(cancellationToken);

            var dto = new BlogPostAddRequestDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                Body = entity.Body,
                ImageUrl = entity.ImagePath,
                PublishedAt = entity.PublishedAt,
                PublishedBy = entity.PublishedBy,
            };

            return dto;
        }
    }
}
