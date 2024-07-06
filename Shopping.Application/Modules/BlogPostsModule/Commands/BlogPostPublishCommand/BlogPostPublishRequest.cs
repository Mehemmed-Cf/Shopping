using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostPublishCommand
{
    public class BlogPostPublishRequest : IRequest<BlogPostPublishRequestDto>
    {
        public int Id { get; set; }
    }
}
