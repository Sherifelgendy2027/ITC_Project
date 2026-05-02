using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(i => i.Person)
                .WithMany(p => p.Instructors)
                .HasForeignKey(i => i.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Organization)
                .WithMany(o => o.Instructors)
                .HasForeignKey(i => i.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.ApprovedByAdmin)
                .WithMany(a => a.ApprovedInstructors)
                .HasForeignKey(i => i.ApprovedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
