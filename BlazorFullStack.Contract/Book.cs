using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStack.Contract
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the author.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please specify the publisher.")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Please provide the inventory number.")]
        public int InventoryNumber { get; set; }

        [Required(ErrorMessage = "Please specify the year of issue.")]
        public int PublishYear { get; set; }
    }
}
