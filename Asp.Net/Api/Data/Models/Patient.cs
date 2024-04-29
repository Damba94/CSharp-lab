using Data.Enums;

namespace Data.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string OIB { get; set; } = null!;
        public string MBO { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string DiagnosisCode { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public bool IsDischarged { get; set; }
        public InsuranceStatus InsuranceStatus { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = null!;
    }
}
