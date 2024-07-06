using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetByIdQuery
{
    public class BlogPostGetByIdRequest : IRequest<BlogPostGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
