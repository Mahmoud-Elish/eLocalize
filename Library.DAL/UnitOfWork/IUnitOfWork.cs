
namespace Library.DAL;

public interface IUnitOfWork
{
    public IBooksRepo BooksRepo { get;}
    public IMembersRepo MembersRepo { get;}
    public IBookMembersRepo BookMembersRepo { get;}
    int Save();
}
