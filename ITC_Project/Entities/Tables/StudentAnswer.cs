using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class StudentAnswer
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; } = string.Empty;
        public DateTime SubmitDate { get; set; }

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Question Question { get; set; } = null!;
    }
}
