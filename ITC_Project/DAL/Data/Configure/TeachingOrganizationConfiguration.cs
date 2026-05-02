using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class TeachingOrganizationConfiguration : IEntityTypeConfiguration<TeachingOrganization>
    {
        public void Configure(EntityTypeBuilder<TeachingOrganization> builder)
        {
            builder.ToTable("TeachingOrganizations");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.LogoPath)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(t => t.Country)
                .WithMany(c => c.TeachingOrganizations)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SubscriptionType)
                .WithMany(s => s.TeachingOrganizations)
                .HasForeignKey(t => t.SubscriptionTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
