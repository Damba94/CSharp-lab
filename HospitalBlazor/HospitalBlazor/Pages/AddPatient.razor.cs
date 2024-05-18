using HospitalBlazor.Dtos;
using HospitalBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace HospitalBlazor.Pages
{
    public partial class AddPatient
    {
        [Inject]
        protected PatientService PatientService { get; set; }
        private CreatePatientRequest newPatient = new CreatePatientRequest();
        private bool isSubmitting = false;
        private string? errorMessage = null;

        private async Task HandleValidSubmit()
        {
            isSubmitting = true;
            errorMessage = null;
            bool success = await PatientService.AddPatientAsync(newPatient);
            if (success)
            {
                NavigationManager.NavigateTo("/", forceLoad: true);
            }
            else
            {
                errorMessage = "There was an error adding the patient. Please try again.";
            }

            isSubmitting = false;
        }
    }
}
