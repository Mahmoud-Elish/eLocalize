using Library.DAL;

namespace Library.BL;

public interface IBooksService
{
    IEnumerable<BookReadVM> GetAll();
    BookDetailsVM GetDetails(Guid id);
    Request Add(BookAddVM bookVM);
    Request Delete(Guid id);

    IEnumerable<Book> GetAvailableBooks(Guid memberId);
    IEnumerable<Book> GetBorrowedBooks(Guid memberId);
}
