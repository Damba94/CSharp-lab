using Data.Enums;

namespace HospitalBlazor.Dtos
{
    public class GetPatient
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
    }
}
