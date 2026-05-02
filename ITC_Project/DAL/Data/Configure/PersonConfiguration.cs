using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.NationalId)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(p => p.Country)
                .WithMany(c => c.People)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
