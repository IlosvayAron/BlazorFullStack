namespace BlazorFullStack.Contract
{
    public interface ICustomerService
    {
        Task<IEnumerable<Member>?> GetAllMembersAsync();

        Task<Member?> GetMemberByIdAsync(int id);

        Task AddMemberAsync(Member member);
    }
}
