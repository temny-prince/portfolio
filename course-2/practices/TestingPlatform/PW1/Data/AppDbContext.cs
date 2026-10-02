using Microsoft.EntityFrameworkCore;
using PW1.Models;
using PW1.Models.JoinTablesModels;

namespace PW1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Direction> Directions => Set<Direction>();
        public DbSet<Test> Tests => Set<Test>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<Attempt> Attempts => Set<Attempt>();
        public DbSet<UserAttemptAnswer> UserAttemptAnswers => Set<UserAttemptAnswer>();
        public DbSet<UserSelectedOption> UserSelectedOptions => Set<UserSelectedOption>();
        public DbSet<UserTextAnswer> UserTextAnswers => Set<UserTextAnswer>();
        public DbSet<TestResult> TestResults => Set<TestResult>();

        public DbSet<TestStudent> TestStudents => Set<TestStudent>();
        public DbSet<TestProject> TestProjects => Set<TestProject>();
        public DbSet<TestCourse> TestCourses => Set<TestCourse>();
        public DbSet<TestGroup> TestGroups => Set<TestGroup>();
        public DbSet<TestDirection> TestDirections => Set<TestDirection>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}