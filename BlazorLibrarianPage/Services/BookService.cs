using BlazorFullStack.Contract;
using System.Net.Http.Json;

namespace BlazorLibrarianPage.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Book>?> GetAllBooksAsync() => _httpClient.GetFromJsonAsync<IEnumerable<Book>>("api/Books");

        public Task<Book?> GetBookByIdAsync(int id) => _httpClient.GetFromJsonAsync<Book?>($"api/Books/{id}");
    }
}
