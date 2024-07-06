using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetBySlugQuery
{
    public class BlogPostGetBySlugRequest : IRequest<BlogPostGetBySlugDto>
    {
        public string Slug { get; set; }
    }
}
