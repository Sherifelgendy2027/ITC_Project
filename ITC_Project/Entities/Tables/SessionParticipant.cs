using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class SessionParticipant
    {
        [Key]
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int StudentId { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime LeaveTime { get; set; }

        // Navigation properties
        public Session Session { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public ICollection<SessionReport> SessionReports { get; set; } = new List<SessionReport>();
    }
}
