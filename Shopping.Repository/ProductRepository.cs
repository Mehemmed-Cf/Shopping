using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using Shopping.Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Repository
{
    class ProductRepository : AsyncRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext db) : base(db)
        {

        }
    }
}
