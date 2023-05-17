using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorFullStack.Contract
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]+\\s[a-zA-Z]+")]
        public string Name { get; set; }

        public string Address { get; set; }

        public int ReadingNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
