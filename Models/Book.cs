using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Book
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Serial { get; set; }
    }
}
