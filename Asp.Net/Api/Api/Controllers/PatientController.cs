using Api.Dtos;
using Application.Enums;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreatePatientRequest createPatientRequest)
        {
            var status = await _patientService
                .CreatPatient(createPatientRequest.ToApplicationDto());
            if (status is CreatePatientStatus.NotCreated)
                return BadRequest();
            return Ok(status);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllPatientsResponse>>> GettAll ()
        {
            var (status, value) = await _patientService
                .GetAll();

            if(status is not GetAllPatientsStatus.Success)
                return BadRequest();
            return Ok(value.Select(
                patient => patient.ToDto()).ToList());
        }

    }
}
