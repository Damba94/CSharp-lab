namespace Application.Dtos
{
    public class GetAllPatientResult
    {
        public int ID { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
