using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DataAccessLayer.Configurations
{
    class ColorEntityTypeConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
            builder.Property(m => m.HexCode).HasColumnType("varchar").HasMaxLength(7).IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Colors");
        }
    }
}
