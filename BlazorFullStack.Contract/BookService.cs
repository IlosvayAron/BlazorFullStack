using System.Net.Http.Json;

namespace BlazorFullStack.Contract
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

        public async Task AddBookAsync(Book book) => await _httpClient.PostAsJsonAsync("api/Books", book);
    }
}
