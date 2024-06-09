using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Models.Entities;

namespace Shopping.DataAccessLayer.Configurations
{
    class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(400).IsRequired();
            builder.Property(m => m.StockCount).HasColumnType("int").IsRequired();
            builder.Property(m => m.Price).HasColumnType("smallint").IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.CategoryId).HasColumnType("int").IsRequired();
            builder.Property(m => m.SizeId).HasColumnType("int").IsRequired();
            builder.Property(m => m.MaterialId).HasColumnType("int").IsRequired();
            builder.Property(m => m.ColorId).HasColumnType("int").IsRequired();
            builder.Property(m => m.BrandId).HasColumnType("int").IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Products");

            builder.HasOne<Category>()
            .WithMany()
            .HasPrincipalKey(m => m.Id)
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Size>()
            .WithMany()
            .HasPrincipalKey(m => m.Id)
            .HasForeignKey(m => m.SizeId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Material>()
            .WithMany()
            .HasPrincipalKey(m => m.Id)
            .HasForeignKey(m => m.MaterialId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Color>()
            .WithMany()
            .HasPrincipalKey(m => m.Id)
            .HasForeignKey(m => m.ColorId)
            .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne<Brand>()
            .WithMany()
            .HasPrincipalKey(m => m.Id)
            .HasForeignKey(m => m.BrandId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
