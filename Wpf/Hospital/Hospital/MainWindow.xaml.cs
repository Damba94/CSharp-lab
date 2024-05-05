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

    // Glavna klasa za WPF prozor
    public partial class MainWindow : Window
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiUrl = "https://localhost:7215/api/Patient";

        private readonly BindingList<PatientViewModel> patients = new BindingList<PatientViewModel>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Povezivanje liste pacijenata s DataGrid kontrolom
            PatientsDataGrid.ItemsSource = patients;


            GetPatients();
        }

        // Metoda za dohvaćanje podataka o pacijentima putem REST API-ja
        private async Task GetPatients()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            // Ovdje bi se otvorio pop-up prozor za unos novog pacijenta
            // Primjerice, mogao bi se koristiti MessageBox za jednostavnost
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