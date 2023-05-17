using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStack.Contract
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ReadingNumber { get; set; }

        public int InventoryNumber { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime ReturnDeadline { get; set; }
    }
}
