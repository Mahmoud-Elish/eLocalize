
namespace Library.DAL;

public class UnitOfWork : IUnitOfWork
{
    public IBooksRepo BooksRepo { get; }
    public IMembersRepo MembersRepo { get; }
    public IBookMembersRepo BookMembersRepo { get; }
    private readonly LibraryContext _context;
    public UnitOfWork(LibraryContext context,IBooksRepo booksRepo,IMembersRepo membersRepo,IBookMembersRepo bookMembersRepo)
    {
        _context = context;
        BooksRepo = booksRepo;
        MembersRepo = membersRepo;
        BookMembersRepo = bookMembersRepo;
    }
    public int Save()
    {
        return _context.SaveChanges();
    }
}
