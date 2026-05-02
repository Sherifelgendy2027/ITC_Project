using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int PersonId { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; } = string.Empty;

        // Navigation properties
        public TeachingOrganization Organization { get; set; } = null!;
        public Person Person { get; set; } = null!;
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<Instructor> ApprovedInstructors { get; set; } = new List<Instructor>();
    }
}
