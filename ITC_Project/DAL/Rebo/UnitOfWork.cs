using DAL.Data;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        protected AppDbContext _context;
        private IDbContextTransaction _currentTransaction;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            // Lookup tables
            Countries = new Repository<Country>(_context);
            TypeOfOrgs = new Repository<TypeOfOrg>(_context);
            SubscriptionTypes = new Repository<SubscriptionType>(_context);

            // Organization & People
            TeachingOrganizations = new Repository<TeachingOrganization>(_context);
            People = new Repository<Person>(_context);
            Admins = new Repository<Admin>(_context);
            Subscriptions = new Repository<Subscription>(_context);

            // Instructors & Courses
            Instructors = new Repository<Instructor>(_context);
            Courses = new Repository<Course>(_context);

            // Students & Enrollments
            Students = new Repository<Student>(_context);
            Enrollments = new Repository<Enrollment>(_context);

            // Sessions & Reports
            Sessions = new Repository<Session>(_context);
            SessionParticipants = new Repository<SessionParticipant>(_context);
            SessionReports = new Repository<SessionReport>(_context);

            // AI Recommendations
            AIRecommendationsForStudents = new Repository<AIRecommendationForStudent>(_context);
            AIRecommendationsForInstructors = new Repository<AIRecommendationForInstructor>(_context);

            // Quizzes & Answers
            Quizzes = new Repository<Quiz>(_context);
            Questions = new Repository<Question>(_context);
            StudentAnswers = new Repository<StudentAnswer>(_context);
        }

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

        public void Dispose()
        {
            _context.Dispose();
            _currentTransaction?.Dispose();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            // Check if a transaction is already in progress to avoid nesting issues.
            if (_currentTransaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            // Use the DbContext to begin a new transaction.
            _currentTransaction = await _context.Database.BeginTransactionAsync();

            return _currentTransaction;
        }

        /// <summary>
        /// Commits the current transaction.
        /// </summary>
        public async Task CommitTransactionAsync()
        {
            try
            {
                if (_currentTransaction == null)
                {
                    throw new InvalidOperationException("No transaction to commit.");
                }
                // Commit the transaction, making all changes permanent.
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                // If the commit fails, an exception is thrown.
                // In a real-world scenario, you might log the error here.
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                // Always dispose of the transaction object.
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        /// <summary>
        /// Rolls back the current transaction, undoing all changes.
        /// </summary>
        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_currentTransaction == null) return;
                // Roll back the transaction to undo all pending changes.
                await _currentTransaction.RollbackAsync();
            }
            finally
            {
                // Always dispose of the transaction object.
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
