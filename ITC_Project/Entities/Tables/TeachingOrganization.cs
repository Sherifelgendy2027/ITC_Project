using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class TeachingOrganization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; } = string.Empty;
        public string LogoPath { get; set; } = string.Empty;

        // Navigation properties
        public Country Country { get; set; } = null!;
        public TypeOfOrg SubscriptionType { get; set; } = null!;
        public ICollection<Admin> Admins { get; set; } = new List<Admin>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
