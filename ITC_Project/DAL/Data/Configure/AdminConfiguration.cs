using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(a => a.Organization)
                .WithMany(o => o.Admins)
                .HasForeignKey(a => a.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Person)
                .WithMany(p => p.Admins)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
