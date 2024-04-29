using Application.Dtos;
using Application.Enums;
using Application.Interfaces;
using Data.Context;
using Data.Models;
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
            };

            _hospitalDbContext.Patients.Add(patient);
            await _hospitalDbContext.SaveChangesAsync();
            return CreatePatientStatus.Created;
        }
    }
}
