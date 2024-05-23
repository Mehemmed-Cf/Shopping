using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Modules.Entities;
using Shopping.Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Repository
{
    public class BrandRepository : AsyncRepository<Brand>, IMaterialRepository
    {
        public BrandRepository(DbContext db) : base(db)
        {
        }
    }
}
