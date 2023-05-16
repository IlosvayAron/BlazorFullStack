using BlazorFullStack.Contract;
using System.Net.Http.Json;

namespace BlazorLibrarianPage.Services
{
    public class RentalService : IRentalService
    {
        private readonly HttpClient _httpClient;

        public RentalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Rental>?> GetAllRentalsAsync() => _httpClient.GetFromJsonAsync<IEnumerable<Rental>?>("api/Rentals");

        public Task<Rental?> GetRentalByIdAsync(int id) => _httpClient.GetFromJsonAsync<Rental?>($"api/Rentals/{id}");
    }
}
