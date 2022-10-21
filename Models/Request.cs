using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [StringLength(20, ErrorMessage = "Max length is 20 chars", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [StringLength(200, ErrorMessage = "Very long", MinimumLength = 2)]
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
