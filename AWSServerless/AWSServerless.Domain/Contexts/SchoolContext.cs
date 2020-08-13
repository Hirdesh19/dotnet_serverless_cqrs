using AWSServerless.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Contexts
{
    public class SchoolContext : DbContext, ISchoolContext
    {
        #region Private Fields

        private readonly IConfiguration _configuration;
        private readonly string _connectionStringName;

        #endregion Private Fields

        #region Public Constructors

        public SchoolContext(IConfiguration configuration = null)
        {
            _configuration = configuration;
            if (_configuration == null)
            {
                string appSettingsFileName = "appsettings";
                string environmentVar = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (!string.IsNullOrEmpty(environmentVar))
                {
                    appSettingsFileName += $".{environmentVar}";
                }
                _configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile($"{appSettingsFileName}.json")
                    .Build();
            }
            _connectionStringName = "SchoolContext";
        }

        #endregion Public Constructors

        public SchoolContext(
            DbContextOptions<DbContext> options,
            string connectionStringName = "SchoolContext"
        ) : base(options)
        {
            _connectionStringName = connectionStringName;
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClassroom> StudentClassrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbContext Context { get { return this; } }

        public async Task<int> Commit()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                //In case we want to use Environment Variables...
                string connectionString = Environment.GetEnvironmentVariable("SCHOOL_CONNECTION_STRING");

                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = "Server=localhost;Database=cqrs_test;User=root;Password=password";
                }
                optionsBuilder.UseMySql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentClassroom>()
                .HasKey(sc => new { sc.ClassRoomId, sc.StudentId });

            modelBuilder.Entity<StudentClassroom>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentClassrooms)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentClassroom>()
                .HasOne(sc => sc.Classroom)
                .WithMany(c => c.StudentClassrooms)
                .HasForeignKey(sc => sc.ClassRoomId);
        }
    }
}