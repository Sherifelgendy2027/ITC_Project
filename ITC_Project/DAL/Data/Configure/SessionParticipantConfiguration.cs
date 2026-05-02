using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configure
{
    public class SessionParticipantConfiguration : IEntityTypeConfiguration<SessionParticipant>
    {
        public void Configure(EntityTypeBuilder<SessionParticipant> builder)
        {
            builder.ToTable("SessionParticipants");

            builder.HasKey(sp => sp.Id);

            builder.HasOne(sp => sp.Session)
                .WithMany(s => s.SessionParticipants)
                .HasForeignKey(sp => sp.SessionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sp => sp.Student)
                .WithMany(s => s.SessionParticipants)
                .HasForeignKey(sp => sp.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
