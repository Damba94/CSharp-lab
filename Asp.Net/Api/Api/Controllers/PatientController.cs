using Api.Dtos;
using Application.Enums;
using Application.Interfaces;
using Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IValidator<CreatePatientRequest> _createPatientRequestValidator;

        public PatientController(
            IPatientService patientService,
            IValidator<CreatePatientRequest> createPatientValidator)
        {
            _patientService = patientService;
            _createPatientRequestValidator = createPatientValidator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreatePatientRequest createPatientRequest)
        {
            await _createPatientRequestValidator
                .ValidateAndThrowAsync(createPatientRequest);

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

        [HttpGet("{patientId}")]
        public async Task<ActionResult<GetAllPatientsResponse>> GetPatient (int patientId)
        {
            var mappedRequest = new GetPatientRequest()
                .ToApplicationDto(patientId);

            var (status, value) = await _patientService
                .GetPatient(mappedRequest);

            if (status is not GetAllPatientsStatus.Success)
                return BadRequest();

            return Ok(value.ToDto());

        }
    }
}
