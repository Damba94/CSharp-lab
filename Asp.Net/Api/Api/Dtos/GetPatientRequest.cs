using Application.Dtos;
using Riok.Mapperly.Abstractions;

namespace Api.Dtos
{
    public class GetPatientRequest
    {
        public int Id { get; set; } 
    }

    [Mapper]
    public static partial class GetPatientRequestMapper
    {
        public static GetPatientDto ToApplicationDto(this GetPatientRequest getPatientRequest,int id)
        {
            var mapped= ToApplicationDto(getPatientRequest);
            mapped.Id = id;
            return mapped;  
        }
        private static partial GetPatientDto ToApplicationDto(this GetPatientRequest getPatientRequest);
    }
}
