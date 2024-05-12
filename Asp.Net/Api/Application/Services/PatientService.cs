using Application.Dtos;
using Application.Enums;
using Application.Interfaces;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PatientService:IPatientService
    {
        private readonly HospitalDbContext _hospitalDbContext;
        public PatientService(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }

        public async Task<CreatePatientStatus> CreatPatient(CreatePatientDto createPatientDto)
        {
            var patient = new Patient
            {
                OIB = createPatientDto.OIB,
                MBO = createPatientDto.MBO,
                FullName = createPatientDto.FullName,
                DateOfBirth = createPatientDto.DateOfBirth,
                Gender = createPatientDto.Gender,
                DiagnosisCode = createPatientDto.DiagnosisCode,
                AdmissionDate = DateTime.Now,
                InsuranceStatus = createPatientDto.InsuranceStatus,
                IsDischarged=false,
            };

            _hospitalDbContext.Patients.Add(patient);
            await _hospitalDbContext.SaveChangesAsync();
            return CreatePatientStatus.Created;
        }

        public async Task<(GetAllPatientsStatus status,List<GetAllPatientResult>? Value)> GetAll()
        {
            var patients = await _hospitalDbContext.Patients
                .AsNoTracking()
                .Select(p=> new GetAllPatientResult
                {
                    ID = p.Id,
                    DateOfBirth=p.DateOfBirth,
                    FullName=p.FullName,

                })
                .ToListAsync();
            return (GetAllPatientsStatus.Success, patients);    
        }

        public async Task<(GetAllPatientsStatus status,GetPatientResult? Value)> GetPatient(GetPatientDto getPatientDto)
        {
            var patient = await _hospitalDbContext.Patients
                .AsNoTracking()
                .Where(p => p.Id == getPatientDto.Id)
                .Select(patient => new GetPatientResult
                {
                    Id = patient.Id,
                    DateOfBirth = patient.DateOfBirth,
                    FullName = patient.FullName,
                    OIB = patient.OIB,
                    MBO = patient.MBO,
                    Gender = patient.Gender,
                    DiagnosisCode = patient.DiagnosisCode,
                    AdmissionDate = patient.AdmissionDate,
                    IsDischarged = patient.IsDischarged,
                })
                .FirstOrDefaultAsync();
            return (GetAllPatientsStatus.Success, patient);
        }
    }
}
