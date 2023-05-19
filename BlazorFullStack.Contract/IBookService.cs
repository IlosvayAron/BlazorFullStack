namespace BlazorFullStack.Contract
{
    public interface IBookService
    {
        Task<IEnumerable<Book>?> GetAllBooksAsync();

        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
    }
}
