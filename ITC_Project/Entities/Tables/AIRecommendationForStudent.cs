using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class AIRecommendationForStudent
    {
        [Key]
        public int Id { get; set; }
        public int SessionReportId { get; set; }
        public string Message { get; set; } = string.Empty;

        // Navigation properties
        public SessionReport SessionReport { get; set; } = null!;
    }
}
