using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;

        // Navigation properties
        public Course Course { get; set; } = null!;
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
