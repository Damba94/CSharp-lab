using Application.Dtos;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IPatientService
    {
        Task<CreatePatientStatus> CreatPatient(CreatePatientDto createPatientDto);
        Task<(GetAllPatientsStatus status, List<GetAllPatientResult>? Value)> GetAll();
        Task<(GetAllPatientsStatus status, List<GetAllPatientResult>? value)> GetAllSorted(bool sortByAdmissionDate = false);
        Task<(GetAllPatientsStatus status, GetPatientResult? Value)> GetPatient(GetPatientDto getPatientDto);
        Task<(GetAllPatientsStatus status, GetPatientResult? value)> GetPatientByOib(GetPatientByOibDto getPatientByOibDto);
    }
}
