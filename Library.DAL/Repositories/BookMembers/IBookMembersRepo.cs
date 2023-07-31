
namespace Library.DAL;

public interface IBookMembersRepo:IGenericRepo<BookMember>
{
    IEnumerable<BookMember> GetAllBookMembers();
    BookMember? GetByIds(Guid memberId, Guid bookId);
    bool Check(Guid memberId,Guid bookId);
}
