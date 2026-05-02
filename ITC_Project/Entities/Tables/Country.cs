using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<TeachingOrganization> TeachingOrganizations { get; set; } = new List<TeachingOrganization>();
        public ICollection<Person> People { get; set; } = new List<Person>();
    }
}
