using Shopping.Domain.Models.Entities;
using Shopping.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Repositories
{
    public interface IBlogPostRepository : IAsyncRepository<BlogPost>
    {

    }
}
