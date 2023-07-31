using Microsoft.EntityFrameworkCore;

namespace Library.DAL;

public class MembersRepo : GenericRepo<Member>, IMembersRepo
{
    private readonly LibraryContext _context;
    public MembersRepo(LibraryContext context) : base(context)
    {
        _context = context;
    }
    public Member? GetByIdWithBooks(Guid id)
    {
        return _context.Set<Member>().Include(m => m.BookMembers)!
              .ThenInclude(m => m.Book).FirstOrDefault(m => m.Id == id);
    }
    public bool CheckExistingUserName(string userName)
    {
        return _context.Set<Member>()
       .Any(m => m.UserName.ToLower() == userName.ToLower());
    }
}
