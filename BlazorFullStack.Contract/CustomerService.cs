using System.Net.Http.Json;

namespace BlazorFullStack.Contract
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddMemberAsync(Member member) => await _httpClient.PostAsJsonAsync("api/Members", member);

        public Task<IEnumerable<Member>?> GetAllMembersAsync() => _httpClient.GetFromJsonAsync<IEnumerable<Member>>("api/Members");

        public Task<Member?> GetMemberByIdAsync(int id) => _httpClient.GetFromJsonAsync<Member?>($"api/Members/{id}");
    }
}
