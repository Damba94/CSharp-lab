using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.OIB)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.MBO)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.Gender)
                .IsRequired();

            builder.Property(x => x.DiagnosisCode)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(x => x.AdmissionDate)
                .IsRequired();

            builder.Property(x => x.DischargeDate)
                .IsRequired(false);

            builder.Property(x => x.IsDischarged)
                .IsRequired();

            builder.Property(x => x.InsuranceStatus)
                .IsRequired();

            builder.HasIndex(x => x.OIB)
                .IsUnique();

            builder.HasIndex(x => x.MBO)
                .IsUnique();

            // One-to-Many relation
            builder.HasMany(x => x.MedicalRecords)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);
        }
    }
}
