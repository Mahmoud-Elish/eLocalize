using Microsoft.EntityFrameworkCore;

namespace Library.DAL;

[PrimaryKey(nameof(MemberId), nameof(BookID))]
public class BookMember
{
    public Guid MemberId { get; set; }
    public Guid BookID { get; set; }

    public Member? Member { get; set; }
    public Book? Book { get; set; }
}
