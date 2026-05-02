using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Lookup tables
        public DbSet<Country> Countries { get; set; }
        public DbSet<TypeOfOrg> TypeOfOrgs { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }

        // Organization & People
        public DbSet<TeachingOrganization> TeachingOrganizations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        // Instructors & Courses
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

        // Students & Enrollments
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        // Sessions & Reports
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionParticipant> SessionParticipants { get; set; }
        public DbSet<SessionReport> SessionReports { get; set; }

        // AI Recommendations
        public DbSet<AIRecommendationForStudent> AIRecommendationsForStudents { get; set; }
        public DbSet<AIRecommendationForInstructor> AIRecommendationsForInstructors { get; set; }

        // Quizzes & Answers
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all IEntityTypeConfiguration classes from this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
