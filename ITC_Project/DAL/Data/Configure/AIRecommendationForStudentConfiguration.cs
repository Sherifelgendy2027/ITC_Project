using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class AIRecommendationForStudentConfiguration : IEntityTypeConfiguration<AIRecommendationForStudent>
    {
        public void Configure(EntityTypeBuilder<AIRecommendationForStudent> builder)
        {
            builder.ToTable("AIRecommendationsForStudents");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(a => a.SessionReport)
                .WithMany(sr => sr.AIRecommendationsForStudents)
                .HasForeignKey(a => a.SessionReportId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
