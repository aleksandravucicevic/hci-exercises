using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Services/CountryService.cs
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using _04_CountryBrowser.Models;

namespace _04_CountryBrowser.Services
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        public async Task<List<Country>> SearchCountryAsync(string name)
        {
            try
            {
                // 1. Konstruiši URL
                var url = $"https://restcountries.com/v3.1/name/{name}";

                // 2. Pošalji zahtjev - ASYNC!
                var response = await _httpClient.GetAsync(url);

                // 3. Provjeri status kod
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Nielsen #9: Specific error message
                    throw new Exception($"Država '{name}' nije pronađena.");
                }

                response.EnsureSuccessStatusCode();

                // 4. Čitaj JSON
                var json = await response.Content.ReadAsStringAsync();

                // 5. Deserializuj
                var countries = JsonSerializer.Deserialize<List<Country>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return countries ?? new List<Country>();
            }
            catch (HttpRequestException)
            {
                // Nielsen #9: Different error type
                throw new Exception("Ne mogu se povezati sa serverom. Provjerite internet konekciju.");
            }
            catch (TaskCanceledException)
            {
                throw new Exception("Zahtjev je trajao predugo. Pokušajte ponovo.");
            }
        }
    }

}
