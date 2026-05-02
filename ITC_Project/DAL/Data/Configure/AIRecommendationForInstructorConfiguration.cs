using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class AIRecommendationForInstructorConfiguration : IEntityTypeConfiguration<AIRecommendationForInstructor>
    {
        public void Configure(EntityTypeBuilder<AIRecommendationForInstructor> builder)
        {
            builder.ToTable("AIRecommendationsForInstructors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(a => a.Session)
                .WithMany(s => s.AIRecommendationsForInstructors)
                .HasForeignKey(a => a.SessionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
