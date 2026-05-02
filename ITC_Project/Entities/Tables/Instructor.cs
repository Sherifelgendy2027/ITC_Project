using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int OrganizationId { get; set; }
        public int ApprovedByAdminId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // Navigation properties
        public Person Person { get; set; } = null!;
        public TeachingOrganization Organization { get; set; } = null!;
        public Admin ApprovedByAdmin { get; set; } = null!;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
