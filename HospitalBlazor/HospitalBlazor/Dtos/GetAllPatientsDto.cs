namespace HospitalBlazor.Dtos
{
    public class GetAllPatientsDto
    {
        public int ID { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
