using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PhotoURL { get; set; }
        public string? ImagePublicId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
