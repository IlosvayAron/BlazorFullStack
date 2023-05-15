using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCustomerPage.Pages
{
    public partial class BookDetails
    {
        [Parameter]
        public int Id { get; set; }

        private RentalList[]? rentals;
        private BookList[]? books;
        private CustomerList[]? customers;

        protected override async Task OnInitializedAsync()
        {
            rentals = await Http.GetFromJsonAsync<RentalList[]>("sample-data/rental.json");
            books = await Http.GetFromJsonAsync<BookList[]>("sample-data/book.json");
            customers = await Http.GetFromJsonAsync<CustomerList[]>("sample-data/customer.json");
        }

        public class RentalList
        {
            public DateTime RentalTime { get; set; }

            public DateTime ReturnDeadline { get; set; }
        }

        public class BookList
        {
            public int Id { get; set; }

            public string? Title { get; set; }

            public string? Author { get; set; }

            public string? Publisher { get; set; }

            public int InventoryNumber { get; set; }

            public int PublishYear { get; set; }
        }

        public class CustomerList
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string? Address { get; set; }

            public string? ReadingNumber { get; set; }

            public DateTime DateOfBirth { get; set; }
        }
    }
}
