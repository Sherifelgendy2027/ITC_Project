using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class AIRecommendationForInstructor
    {
        [Key]
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string Message { get; set; } = string.Empty;

        // Navigation properties
        public Session Session { get; set; } = null!;
    }
}
