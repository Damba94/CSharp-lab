using Data.Enums;

namespace Application.Dtos
{
    public class CreatePatientDto
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
