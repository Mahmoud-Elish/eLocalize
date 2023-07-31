using System.ComponentModel.DataAnnotations;

namespace Library.BL;

public class BookAddVM
{
    [Required]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "The length of the Book's {0} must be between {1} and {2} characters.")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [Range(1, 50, ErrorMessage = "The {0} range between {1} and {2}")]
    public int Quantity { get; set; }
}
