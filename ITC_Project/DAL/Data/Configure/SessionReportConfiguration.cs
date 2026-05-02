using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class SessionReportConfiguration : IEntityTypeConfiguration<SessionReport>
    {
        public void Configure(EntityTypeBuilder<SessionReport> builder)
        {
            builder.ToTable("SessionReports");

            builder.HasKey(sr => sr.Id);

            builder.Property(sr => sr.EyeFocusScore)
                .IsRequired()
                .HasDefaultValue(100);

            builder.Property(sr => sr.InteractionScore)
                .IsRequired()
                .HasDefaultValue(100);

            builder.HasOne(sr => sr.SessionParticipant)
                .WithMany(sp => sp.SessionReports)
                .HasForeignKey(sr => sr.SessionParticipantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
