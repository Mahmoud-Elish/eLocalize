using Microsoft.EntityFrameworkCore;

namespace Library.DAL;

public class BooksRepo : GenericRepo<Book>, IBooksRepo
{
    private readonly LibraryContext _context;
    public BooksRepo(LibraryContext context) : base(context)
    {
        _context=context;
    }
    public Book? GetByIdWithMembers(Guid id)
    {
        return _context.Set<Book>().Include(b=>b.BookMembers)!
               .ThenInclude(b=>b.Member).FirstOrDefault(b=>b.Id == id);
    }
    public bool CheckExistingTitle(string title)
    {
        return _context.Set<Book>()
        .Any(b => b.Title.ToLower() == title.ToLower());
    }
    public IEnumerable<Book> GetBorrowedBooks(Guid id)
    {
        var member = _context.Set<Member>()
         .Include(m => m.BookMembers)
         .ThenInclude(bm => bm.Book)
         .FirstOrDefault(m => m.Id == id);

        if (member != null)
        {
            return member.BookMembers.Select(bm => bm.Book).ToList();
        }

        return Enumerable.Empty<Book>();
    }
}
