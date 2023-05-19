namespace BlazorFullStack.Contract
{
    public interface IRentalService
    {
        Task<IEnumerable<Rental>?> GetAllRentalsAsync();

        Task<Rental?> GetRentalByIdAsync(int id);
        Task<IEnumerable<Rental>?> GetRentalsByReadingNumberAsync(int readingNumber);

        Task AddRentalAsync(Rental rental);

        Task DeleteRentalAsync(int id);
    }
}
