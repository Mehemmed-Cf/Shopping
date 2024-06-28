using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Models.Entities;

namespace Shopping.DataAccessLayer.Configurations
{
    class ContactPostEntityTypeConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.FullName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Subject).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Content).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Answer).HasColumnType("nvarchar(max)");
            builder.Property(m => m.AnsweredAt).HasColumnType("datetime");
            builder.Property(m => m.AnsweredBy).HasColumnType("int");


            builder.HasKey(m => m.Id);
            builder.ToTable("ContactPosts");
        }
    }
}
