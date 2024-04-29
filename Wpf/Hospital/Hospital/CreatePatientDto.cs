using System;

namespace Hospital
{
    public class CreatePatientDto
    {
        public string OIB { get; set; }
        public string MBO { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string DiagnosisCode { get; set; }
        public InsuranceStatus InsuranceStatus { get; set; }


    }
}
