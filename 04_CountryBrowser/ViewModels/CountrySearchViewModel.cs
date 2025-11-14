using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using _04_CountryBrowser.Models;
using _04_CountryBrowser.Services;

namespace _04_CountryBrowser.ViewModels
{
    // VAŽNO: partial class omogućava source generation
    public partial class CountrySearchViewModel : ObservableObject
    {
        private readonly CountryService _service;

        [ObservableProperty]
        private string _searchQuery = string.Empty; // Inicijalizuj sa praznim stringom

        [ObservableProperty]
        private ObservableCollection<Country> _countries;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private string _statusMessage;

        // Ove partial metode se automatski pozivaju kad se property promijeni
        partial void OnSearchQueryChanged(string value)
        {
            SearchCommand.NotifyCanExecuteChanged();
        }

        partial void OnIsLoadingChanged(bool value)
        {
            SearchCommand.NotifyCanExecuteChanged();
        }

        public CountrySearchViewModel()
        {
            _service = new CountryService();
            _countries = new ObservableCollection<Country>();

            // DEBUG
            System.Diagnostics.Debug.WriteLine("CountrySearchViewModel created!");
        }

        [RelayCommand(CanExecute = nameof(CanSearch))]
        private async Task Search()
        {
            System.Diagnostics.Debug.WriteLine($"Search called with query: '{SearchQuery}'");

            IsLoading = true;
            StatusMessage = "Tražim...";

            try
            {
                var results = await _service.SearchCountryAsync(SearchQuery);

                Countries.Clear();
                foreach (var country in results)
                {
                    Countries.Add(country);
                }

                StatusMessage = results.Count > 0
                    ? $"Pronađeno: {results.Count}"
                    : "Nema rezultata. Pokušajte drugi naziv.";

                System.Diagnostics.Debug.WriteLine($"Search completed. Found {results.Count} results.");
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
                Countries.Clear();
                System.Diagnostics.Debug.WriteLine($"Search error: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private bool CanSearch()
        {
            var canSearch = !string.IsNullOrWhiteSpace(SearchQuery) && !IsLoading;
            System.Diagnostics.Debug.WriteLine($"CanSearch: {canSearch} (Query: '{SearchQuery}', IsLoading: {IsLoading})");
            return canSearch;
        }
    }
}