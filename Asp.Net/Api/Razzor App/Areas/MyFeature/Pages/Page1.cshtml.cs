using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razzor_App.MyFeature.Pages
{
    public class Page1Model : PageModel
    {
        private readonly PatientService _patientService;

        public Page1Model(PatientService patientService)
        {
            _patientService = patientService;
        }

        public List<PatientViewModel> Patients { get; set; }

        public async Task OnGet()
        {
            var patientsData = await _patientService.GetPatients();
            Patients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PatientViewModel>>(patientsData);
        }
    }

    public class PatientViewModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Diagnosis { get; set; }
        // ...
    }

}
