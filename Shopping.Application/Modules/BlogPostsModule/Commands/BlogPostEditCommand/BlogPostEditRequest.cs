using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostEditCommand
{
    public class BlogPostEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? PublishedBy { get; set; }
    }
}
