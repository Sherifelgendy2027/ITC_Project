using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public Instructor Instructor { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
