using System.Net;
using System.Net.Http.Json;

namespace BlazorFullStack.Contract
{
    public class RentalService : IRentalService
    {
        private readonly HttpClient _httpClient;

        public RentalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddRentalAsync(Rental rental) => await _httpClient.PostAsJsonAsync("api/Rentals", rental);

        public async Task DeleteRentalAsync(int id) => await _httpClient.DeleteAsync($"api/Rentals/{id}");

        public Task<IEnumerable<Rental>?> GetAllRentalsAsync() => _httpClient.GetFromJsonAsync<IEnumerable<Rental>?>("api/Rentals");

        public Task<IEnumerable<Rental>?> GetRentalsByReadingNumberAsync(int readingNumber) => _httpClient.GetFromJsonAsync<IEnumerable<Rental>?>($"api/Rentals/member/{readingNumber}");

        public async Task<Rental?> GetRentalByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Rental?>($"api/Rentals/{id}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
