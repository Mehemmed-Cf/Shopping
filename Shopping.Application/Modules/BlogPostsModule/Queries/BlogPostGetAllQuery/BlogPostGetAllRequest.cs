using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetAllQuery
{
    public class BlogPostGetAllRequest : IRequest<IEnumerable<BlogPostGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
