using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace YourNamespace
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum InsuranceStatus
    {
        Insured,
        Uninsured
    }

    public class PatientViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }


    public partial class MainWindow : Window
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiUrl = "https://localhost:7215/api/Patient";

        private readonly BindingList<PatientViewModel> patients = new BindingList<PatientViewModel>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;


            PatientsDataGrid.ItemsSource = patients;


            LoadPatientsAsync();
        }

        private async void LoadPatientsAsync()
        {
            try
            {
                await GetPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading patients: " + ex.Message);
            }
        }

        private async Task GetPatients()
        {

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(5);

                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        List<GetAllPatientsResult> apiResponse = await response.Content.ReadAsAsync<List<GetAllPatientsResult>>();

                        foreach (var patient in apiResponse)
                        {
                            patients.Add(new PatientViewModel
                            {
                                Id = patient.Id,
                                FullName = patient.FullName,
                                DateOfBirth = patient.DateOfBirth
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error fetching patients data: " + response.ReasonPhrase);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }



        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Placeholder for adding new patient popup form.");
        }


        public class GetAllPatientsResult
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}