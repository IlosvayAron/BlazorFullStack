using BlazorFullStack.Contract;

namespace BlazorLibrarianPage.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Member>?> GetAllMembersAsync();

        Task<Member?> GetMemberByIdAsync(int id);

        Task AddMemberAsync(Member member);
    }
}
