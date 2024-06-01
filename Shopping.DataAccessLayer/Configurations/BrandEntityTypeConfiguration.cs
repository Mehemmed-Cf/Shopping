using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccessLayer.Configurations
{
    class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Brands");
        }
    }
}
