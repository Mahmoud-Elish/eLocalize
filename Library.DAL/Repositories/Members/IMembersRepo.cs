
namespace Library.DAL;

public interface IMembersRepo :IGenericRepo<Member>
{
    Member? GetByIdWithBooks(Guid id);
    bool CheckExistingUserName(string userName);
}
