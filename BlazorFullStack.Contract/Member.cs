using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStack.Contract
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "Valid characters include (A-Z) (a-z) (' space -)")]
        [MaxLength(50, ErrorMessage = "The name can only be 50 characters long.")]
        public string Name { get; set; }

        public string Address { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Reading Number can only contain numbers.")]
        public int ReadingNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
