using Api.Dtos;
using Application.Dtos;
using Application.Enums;
using Application.Interfaces;
using FluentValidation;
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
        public async Task<ActionResult> Create([FromBody] CreatePatientRequest createPatientRequest)
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
        public async Task<ActionResult<List<GetAllPatientsResponse>>> GettAll()
        {
            var (status, value) = await _patientService
                .GetAll();

            if (status is not GetAllPatientsStatus.Success)
                return BadRequest();

            return Ok(value.Select(
                patient => patient.ToDto()).ToList());
        }

        [HttpGet("{patientId}")]
        public async Task<ActionResult<GetPatientResponse>> GetPatient(int patientId)
        {
            var mappedRequest = new GetPatientRequest()
                .ToApplicationDto(patientId);

            var (status, value) = await _patientService
                .GetPatient(mappedRequest);

            if (status is not GetAllPatientsStatus.Success)
                return BadRequest();

            return Ok(value.ToDto());

        }

        [HttpGet("byOib/{oib}")]
        public async Task<ActionResult<GetPatientResult>> GetPatientByOib(string oib)
        {
            var mappedRequest = new GetPatientByOibRequest()
                .ToApplicationDto(oib);

            var (status, value) = await _patientService
                .GetPatientByOib(mappedRequest);

            if (status is not GetAllPatientsStatus.Success)
            {
                return NotFound();
            }

            return Ok(value.ToDto);
        }

        [HttpGet("sorted")]
        public async Task<ActionResult<List<GetAllPatientResult>>> GetAllPatients([FromQuery] bool sortByAdmissionDate = false)
        {
            var (status, patients) = await _patientService.GetAllSorted(sortByAdmissionDate);

            if (status is not GetAllPatientsStatus.Success)
            {
                return BadRequest();
            }

            return Ok(patients);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<GetAllPatientResult>>> Filter([FromQuery] bool sortByAdmissionDate = false)
        {
            var (status, patients) = await _patientService.GetAllSorted(sortByAdmissionDate);

            if (status is not GetAllPatientsStatus.Success)
            {
                return BadRequest();
            }

            return Ok(patients);
        }
    }
}
