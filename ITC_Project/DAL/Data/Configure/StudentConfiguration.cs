using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Person)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.TeachingOrganization)
                .WithMany(o => o.Students)
                .HasForeignKey(s => s.TeachingOrganizationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
