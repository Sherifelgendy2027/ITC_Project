using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class TypeOfOrgConfiguration : IEntityTypeConfiguration<TypeOfOrg>
    {
        public void Configure(EntityTypeBuilder<TypeOfOrg> builder)
        {
            builder.ToTable("TypeOfOrg");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
