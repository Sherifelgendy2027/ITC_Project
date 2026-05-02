using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int SubscribedByAdminId { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public TeachingOrganization Organization { get; set; } = null!;
        public Admin SubscribedByAdmin { get; set; } = null!;
    }
}
