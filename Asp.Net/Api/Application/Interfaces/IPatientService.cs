using Application.Dtos;
using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPatientService
    {
        Task<CreatePatientStatus> CreatPatient(CreatePatientDto createPatientDto);
        Task<(GetAllPatientsStatus status, List<GetAllPatientResult>? Value)> GetAll();
    }
}
