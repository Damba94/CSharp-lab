using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzor_App.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7215/"); 
        }

        public async Task<string> GetPatients()
        {
            var response = await _httpClient.GetAsync("api/Patient"); 
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(); 
        }
    }
}

