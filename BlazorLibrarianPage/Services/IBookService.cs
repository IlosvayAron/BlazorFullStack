using BlazorFullStack.Contract;

namespace BlazorLibrarianPage.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>?> GetAllBooksAsync();

        Task<Book?> GetBookByIdAsync(int id);
    }
}
