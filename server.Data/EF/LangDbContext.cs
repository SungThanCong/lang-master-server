using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using server.Data.Configurations;
using server.Data.Entities;
using server.Data.Extensions;

namespace server.Data.EF
{
    public class LangDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public LangDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppRoleConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new BillConfiguration());
            builder.ApplyConfiguration(new BillInfoConfiguration());
            builder.ApplyConfiguration(new ClassConfiguration());
            builder.ApplyConfiguration(new ClassTimeConfiguration());
            builder.ApplyConfiguration(new ColumnCourseConfiguration());
            builder.ApplyConfiguration(new ColumnTranscriptConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseTypeConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ExamConfiguration());
            builder.ApplyConfiguration(new LearningConfiguration());
            builder.ApplyConfiguration(new LecturerConfiguration());
            builder.ApplyConfiguration(new LevelConfiguration());
            builder.ApplyConfiguration(new ParameterConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new TeachingConfiguration());
            builder.ApplyConfiguration(new TestingConfiguration());
            builder.ApplyConfiguration(new TestTypeConfiguration());
            builder.ApplyConfiguration(new TimeFrameConfiguration());
            builder.ApplyConfiguration(new RefreshTokenConfiguration());
            builder.ApplyConfiguration(new CenterConfiguration());
            builder.ApplyConfiguration(new AttendanceConfiguration());






            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            builder.Seed();

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillInfo> BillInfos { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassTime> ClassTimes { get; set; }
        public DbSet<ColumnCourse> ColumnCourses { get; set; }
        public DbSet<ColumnTranscript> ColumnTranscripts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Learning> Learnings { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public DbSet<Testing> Testings { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<TimeFrame> TimeFrames { get; set; }

        public DbSet<RefreshTokens> RefreshTokens { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

    }

    public class LangDbContextFactory : IDesignTimeDbContextFactory<LangDbContext>
    {
        public LangDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();
            var connectionString = configuration.GetConnectionString("LangcenterDatabase");

            var optionBuilder = new DbContextOptionsBuilder<LangDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new LangDbContext(optionBuilder.Options);
        }
    }
}
