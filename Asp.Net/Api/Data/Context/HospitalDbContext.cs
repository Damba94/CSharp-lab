using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Data.Context
{
    public class HospitalDbContext : DbContext
    {
        private readonly ILogger<HospitalDbContext> _logger;
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options,
            ILogger<HospitalDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(log => _logger.LogInformation(log));
        }
    }
}

