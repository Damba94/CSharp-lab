using Api.Dtos;
using Application.Enums;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreatePatientRequest createPatientRequest)
        {
            var status = await _patientService
                .CreatPatient(createPatientRequest.ToApplicationDto());
            if (status is CreatePatientStatus.Created)
                return BadRequest();
            return Ok(status);
        }

    }
}
