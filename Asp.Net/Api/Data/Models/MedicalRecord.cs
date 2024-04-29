namespace Data.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime RecordDate { get; set; }
        public string Description { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;
    }
}
