using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/Country.cs
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace _04_CountryBrowser.Models
{
    public class Country
    {
        [JsonPropertyName("name")]
        public CountryName Name { get; set; }

        [JsonPropertyName("capital")]
        public List<string> Capital { get; set; }

        [JsonPropertyName("population")]
        public long Population { get; set; }

        [JsonPropertyName("flags")]
        public Flags FlagUrls { get; set; }

        // Display properties - Nielsen #6
        public string DisplayName => Name?.Common ?? "Unknown";
        public string CapitalCity => Capital?.FirstOrDefault() ?? "N/A";
        public string PopulationText => $"{Population:N0}";
        public string FlagUrl => FlagUrls?.Png;
    }

    public class CountryName
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }
    }

    public class Flags
    {
        [JsonPropertyName("png")]
        public string Png { get; set; }
    }
}