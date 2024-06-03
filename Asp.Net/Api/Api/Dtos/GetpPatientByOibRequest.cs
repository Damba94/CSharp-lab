using Application.Dtos;
using Riok.Mapperly.Abstractions;

namespace Api.Dtos
{
    public class GetPatientByOibRequest
    {
        public string Oib { get; set; } = null!;
    }

    [Mapper]
    public static partial class GetPatientByOibRequestMapper
    {
        public static GetPatientByOibDto ToApplicationDto(this GetPatientByOibRequest getPatientRequest, string oib)
        {
            var mapped = ToApplicationDto(getPatientRequest);
            mapped.Oib = oib;
            return mapped;
        }
        private static partial GetPatientByOibDto ToApplicationDto(this GetPatientByOibRequest getPatientRequest);
    }
}

