using Data.Enums;

namespace HospitalBlazor.Dtos
{
    public class CreatePatientRequest
    {
        public string OIB { get; set; } = null!;
        public string MBO { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string DiagnosisCode { get; set; } = null!;
        public InsuranceStatus InsuranceStatus { get; set; }

    }
}
