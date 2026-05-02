using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int TeachingOrganizationId { get; set; }

        // Navigation properties
        public Person Person { get; set; } = null!;
        public TeachingOrganization TeachingOrganization { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<SessionParticipant> SessionParticipants { get; set; } = new List<SessionParticipant>();
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
    }
}
