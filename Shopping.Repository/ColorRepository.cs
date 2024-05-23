using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Modules.Entities;
using Shopping.Infrastructure.Abstracts;
using Shopping.Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Repository
{
    public class ColorRepository : AsyncRepository<Color>, IColorRepository
    {
        public ColorRepository(DbContext db) : base(db)
        {
        }
    }
}
