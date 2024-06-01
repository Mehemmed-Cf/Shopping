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
    class BlogPostEntityTypeConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(400).IsRequired();
            builder.Property(m => m.Body).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.CategoryId).HasColumnType("int").IsRequired();
            builder.Property(m => m.PublishedBy).HasColumnType("int");
            builder.Property(m => m.PublishedAt).HasColumnType("datetime");

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("BlogPosts");

            builder.HasOne<Category>()
             .WithMany()
             .HasPrincipalKey(m => m.Id)
             .HasForeignKey(m => m.CategoryId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
