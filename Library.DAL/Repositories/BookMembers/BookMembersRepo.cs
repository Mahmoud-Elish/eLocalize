using Microsoft.EntityFrameworkCore;

namespace Library.DAL;

public class BookMembersRepo : GenericRepo<BookMember>, IBookMembersRepo
{
    private readonly LibraryContext _context;
    public BookMembersRepo(LibraryContext context) : base(context)
    {
        _context = context;
    }
    public IEnumerable<BookMember> GetAllBookMembers()
    {
        return _context.Set<BookMember>().Include(mb => mb.Book)
            .Include(mb => mb.Member);
    }
    public bool Check(Guid memberId, Guid bookId)
    {
        return _context.Set<BookMember>()
            .Any(b => b.MemberId == memberId && b.BookID == bookId);
    }
    public BookMember? GetByIds(Guid memberId, Guid bookId)
    {
        return _context.Set<BookMember>()
       .SingleOrDefault(bm => bm.MemberId == memberId && bm.BookID == bookId);
    }
}
