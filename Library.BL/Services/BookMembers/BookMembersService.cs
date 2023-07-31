using Library.DAL;

namespace Library.BL;

public class BookMembersService : IBookMembersService
{
    private readonly IUnitOfWork _unitOfWork;
    public BookMembersService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<BookMemberReadVM> GetAll()
    {
        var bookMeberss = _unitOfWork.BookMembersRepo.GetAllBookMembers()
            .Select(b => new BookMemberReadVM
            {
                MemberUSerName = b.Member!.UserName,
                BookTitle=b.Book!.Title
               
            });
        return bookMeberss;
    }
    public Request BorrowBook(Guid memberId, Guid bookId)
    {
        if (_unitOfWork.BookMembersRepo.Check(memberId, bookId))
        {
            return new Request { Status = false, Message = Message.Borrow };
        }
        Book? book = _unitOfWork.BooksRepo.GetById(bookId);
        if (book is null)
        {
            return new Request { Status = false, Message = Message.NotFound };
        }
        else if (book.AvailableQuantity == 0)
        {
            return new Request { Status = false, Message = Message.Books };
        }

        book.AvailableQuantity--;
        BookMember? bookMember = new()
        {
            MemberId = memberId,
            BookID = bookId,
        };
        _unitOfWork.BookMembersRepo.Add(bookMember);
        _unitOfWork.Save();
        return new Request { Status = true, Message = Message.Success };

    }
    public Request LendBook(Guid memberId, Guid bookId)
    {
        if (!_unitOfWork.BookMembersRepo.Check(memberId, bookId))
        {
            return new Request { Status = false, Message = Message.Lend };
        }
        Book? book = _unitOfWork.BooksRepo.GetById(bookId);
        if (book is null)
        {
            return new Request { Status = false, Message = Message.NotFound };
        }
        BookMember bookMember = _unitOfWork.BookMembersRepo.GetByIds(memberId, bookId)!;
        _unitOfWork.BookMembersRepo.Delete(bookMember!);
        book.AvailableQuantity++;
        _unitOfWork.Save();
        return new Request { Status = true, Message = Message.Success };

    }
}
