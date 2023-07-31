
namespace Library.BL;

public class MemberDetailsVM
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public IEnumerable<BookChildVM>? Books { get; set; }
}
public class BookChildVM   
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}