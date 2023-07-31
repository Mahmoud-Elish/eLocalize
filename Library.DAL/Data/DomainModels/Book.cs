using System.ComponentModel.DataAnnotations;

namespace Library.DAL;

public class Book
{
    public Guid Id { get; set; }
    [MinLength(3)]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;
    [Range(1, 50)]
    public int Quantity { get; set; }
    public int AvailableQuantity { get; set; }
    public DateTime AddTime { get; set; }

    public IEnumerable<BookMember>? BookMembers { get; set;}
}
