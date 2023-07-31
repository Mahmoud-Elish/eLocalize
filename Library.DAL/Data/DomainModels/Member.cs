using System.ComponentModel.DataAnnotations;

namespace Library.DAL;

public class Member
{
    public Guid Id { get; set; }
    [MinLength(3)]
    [MaxLength(30)]
    public string UserName { get; set; } = string.Empty;

    public IEnumerable<BookMember>? BookMembers { get; set; }
}
