using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.RecordDate)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            // Many-to-One relacija sa Patient
            builder.HasOne(x => x.Patient)
                .WithMany(x => x.MedicalRecords)
                .HasForeignKey(x => x.PatientId);
        }
    }
}
