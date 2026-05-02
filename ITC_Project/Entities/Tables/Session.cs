using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public bool IsEnd { get; set; }
        public bool IsCameraRequired { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Navigation properties
        public Course Course { get; set; } = null!;
        public ICollection<SessionParticipant> SessionParticipants { get; set; } = new List<SessionParticipant>();
        public ICollection<AIRecommendationForInstructor> AIRecommendationsForInstructors { get; set; } = new List<AIRecommendationForInstructor>();
    }
}
