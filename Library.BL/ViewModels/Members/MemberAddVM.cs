using System.ComponentModel.DataAnnotations;

namespace Library.BL;

public class MemberAddVM
{
    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "The length of {0} must be between {1} and {2} characters.")]
    public string UserName { get; set; } = string.Empty;
}
