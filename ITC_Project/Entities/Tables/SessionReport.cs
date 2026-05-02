using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class SessionReport
    {
        [Key]
        public int Id { get; set; }
        public int SessionParticipantId { get; set; }
        public double EyeFocusScore { get; set; } = 100;
        public double InteractionScore { get; set; } = 100;

        // Navigation properties
        public SessionParticipant SessionParticipant { get; set; } = null!;
        public ICollection<AIRecommendationForStudent> AIRecommendationsForStudents { get; set; } = new List<AIRecommendationForStudent>();
    }
}
