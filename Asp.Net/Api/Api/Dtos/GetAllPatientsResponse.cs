using Application.Dtos;
using Riok.Mapperly.Abstractions;

namespace Api.Dtos
{
    public class GetAllPatientsResponse
    {
        public int ID { get; set; } 
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
    [Mapper]
    public static partial class GetAllPatientsResponseMapper
    {
        public static partial GetAllPatientsResponse ToDto(this GetAllPatientResult getAllPatientResult);
    }
}
