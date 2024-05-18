using HospitalBlazor.Dtos;
using System.Net.Http.Json;

namespace HospitalBlazor.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetAllPatientsDto>> GetPatientsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<GetAllPatientsDto>>("https://localhost:7215/api/Patient");
        }

        public async Task<GetPatient> GetPatientByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GetPatient>($"https://localhost:7215/api/Patient/{id}");
        }

        public async Task<bool> AddPatientAsync(CreatePatientRequest newPatient)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7215/api/Patient", newPatient);
            return response.IsSuccessStatusCode;
        }
    }
}
