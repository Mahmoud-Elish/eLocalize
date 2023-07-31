
namespace Library.BL;

public interface IBookMembersService
{
    IEnumerable<BookMemberReadVM> GetAll();
    Request BorrowBook(Guid memberId, Guid bookId);
    Request LendBook(Guid memberId, Guid bookId);
}
