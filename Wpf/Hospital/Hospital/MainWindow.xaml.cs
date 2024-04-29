using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

public class DodajPacijentaViewModel : BaseViewModel
{
    private readonly HttpClient _httpClient;

    private string _oib;
    private string _mbo;
    private string _imePrezime;
    private DateTime _datumRodjenja;
    private Gender _spol;
    private string _dijagnoza;
    private ICommand _dodajPacijentaCommand;

    public DodajPacijentaViewModel()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:5001/api/"); 

    }

    public string OIB
    {
        get { return _oib; }
        set
        {
            _oib = value;
            OnPropertyChanged(nameof(OIB));
        }
    }

    // Dodajte svojstva za ostale informacije o pacijentu...

    public ICommand DodajPacijentaCommand
    {
        get
        {
            return _dodajPacijentaCommand ?? (_dodajPacijentaCommand = new RelayCommand(async param => await DodajPacijentaAsync()));
        }
    }

    private async Task DodajPacijentaAsync()
    {
        var createPatientDto = new Hospital.CreatePatientDto
        {
            OIB = OIB,
            MBO = MBO,
            
        };

        var json = JsonConvert.SerializeObject(createPatientDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("Pacijent", content);
            response.EnsureSuccessStatusCode(); // Ovo će baciti izuzetak ako je status odgovora neuspešan

            // Opciono: prikažite korisniku poruku o uspešnom dodavanju pacijenta
        }
        catch (HttpRequestException ex)
        {
            // Ovde možete rukovati greškama koje se dogode prilikom slanja zahteva
            // Na primer, možete prikazati poruku korisniku ili logovati grešku
            // MessageBox.Show($"Greška prilikom slanja zahteva: {ex.Message}");
        }
    }
}
