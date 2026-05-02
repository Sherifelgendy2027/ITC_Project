using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Lookup tables
        public IRepository<Country> Countries { get; }
        public IRepository<TypeOfOrg> TypeOfOrgs { get; }
        public IRepository<SubscriptionType> SubscriptionTypes { get; }

        // Organization & People
        public IRepository<TeachingOrganization> TeachingOrganizations { get; }
        public IRepository<Person> People { get; }
        public IRepository<Admin> Admins { get; }
        public IRepository<Subscription> Subscriptions { get; }

        // Instructors & Courses
        public IRepository<Instructor> Instructors { get; }
        public IRepository<Course> Courses { get; }

        // Students & Enrollments
        public IRepository<Student> Students { get; }
        public IRepository<Enrollment> Enrollments { get; }

        // Sessions & Reports
        public IRepository<Session> Sessions { get; }
        public IRepository<SessionParticipant> SessionParticipants { get; }
        public IRepository<SessionReport> SessionReports { get; }

        // AI Recommendations
        public IRepository<AIRecommendationForStudent> AIRecommendationsForStudents { get; }
        public IRepository<AIRecommendationForInstructor> AIRecommendationsForInstructors { get; }

        // Quizzes & Answers
        public IRepository<Quiz> Quizzes { get; }
        public IRepository<Question> Questions { get; }
        public IRepository<StudentAnswer> StudentAnswers { get; }

        int Save();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> SaveAsync();
    }
}
