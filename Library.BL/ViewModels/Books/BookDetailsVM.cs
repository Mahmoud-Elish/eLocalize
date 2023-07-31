
namespace Library.BL;

public class BookDetailsVM
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int AvailableQuantity { get; set; }
    public DateTime AddTime { get; set; }

    public IEnumerable<MemberChildVM>? Members { get; set; } 
}
public class MemberChildVM    
{
    public string Id { get; set; } = string.Empty;    
    public string UserName { get; set; } = string.Empty;
}
