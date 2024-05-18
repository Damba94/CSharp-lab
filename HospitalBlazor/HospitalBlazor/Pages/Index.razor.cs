using HospitalBlazor.Dtos;
using HospitalBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace HospitalBlazor.Pages
{
    public partial class Index
    {
        [Inject]
        protected PatientService PatientService { get; set; }

        protected List<GetAllPatientsDto> patients;
        protected GetPatient selectedPatient;

        protected override async Task OnInitializedAsync()
        {
            patients = await PatientService.GetPatientsAsync();
        }

        protected async Task ShowDetails(int id)
        {
            selectedPatient = await PatientService.GetPatientByIdAsync(id);
        }

        protected void CloseDetails()
        {
            selectedPatient = null;
        }
    }
}