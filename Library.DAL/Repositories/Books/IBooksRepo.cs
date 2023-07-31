
namespace Library.DAL;

public interface IBooksRepo :IGenericRepo<Book>
{
    Book? GetByIdWithMembers(Guid id);
    bool CheckExistingTitle(string title);
    IEnumerable<Book> GetBorrowedBooks(Guid id);
}
