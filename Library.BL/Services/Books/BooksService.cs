using Library.DAL;

namespace Library.BL;

public class BooksService : IBooksService 
{
    private readonly IUnitOfWork _unitOfWork;
    public BooksService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<BookReadVM> GetAll()
    {
        var books = _unitOfWork.BooksRepo.GetAll().OrderBy(b => b.AddTime)
            .Select(b=> new BookReadVM
            {
                Id = b.Id.ToString(),
                Title = b.Title,
                Quantity = b.Quantity,
                AvailableQuantity = b.AvailableQuantity,

            });
        return books;
    }
    public BookDetailsVM GetDetails(Guid id)
    {
        Book? book = _unitOfWork.BooksRepo.GetByIdWithMembers(id);
        if (book is null) return null!;
        return new BookDetailsVM
        {
            Id = book!.Id.ToString(),
            Title = book.Title,
            Quantity = book.Quantity,
            AvailableQuantity = book.AvailableQuantity,
            AddTime = book.AddTime,
            Members = book.BookMembers?.Select(b=> new MemberChildVM
            {
                Id=b.MemberId.ToString(),
                UserName=b.Member!.UserName
            })
        };
    }
    public Request Add(BookAddVM bookVM)
    {
        if (_unitOfWork.BooksRepo.CheckExistingTitle(bookVM.Title))
        {
            return new Request { Status = false, Message = Message.BookTitle };
        }
        Book? book = new()
        {
            Id=Guid.NewGuid(),
            Title = bookVM.Title,
            Quantity=bookVM.Quantity,
            AvailableQuantity=bookVM.Quantity,
            AddTime=DateTime.Now,
        };
        _unitOfWork.BooksRepo.Add(book);
        _unitOfWork.Save();

        return new Request { Status = true, Message = Message.Success};
    }
    public Request Delete(Guid id)
    {
        Book? book = _unitOfWork.BooksRepo.GetById(id);
        if (book is null)
        {
            return new Request { Status = false, Message = Message.NotFound };
        }
        else if (book.Quantity != book.AvailableQuantity)
        {
            return new Request { Status = false, Message = Message.BookDelete };
        }

        _unitOfWork.BooksRepo.Delete(book);
        _unitOfWork.Save();
        return new Request { Status = true, Message = Message.Success };
    }
    public IEnumerable<Book> GetAvailableBooks(Guid memberId)
    {
        var borrowedBooks = _unitOfWork.BooksRepo.GetBorrowedBooks(memberId);

        var availableBooks = _unitOfWork.BooksRepo.GetAll()
           .Where(book => !borrowedBooks.Any(borrowedBook => borrowedBook.Id == book.Id) && book.AvailableQuantity>0)
        .ToList();

        return availableBooks;
    }
    public IEnumerable<Book> GetBorrowedBooks(Guid memberId) 
    {
        var borrowedBooks = _unitOfWork.BooksRepo.GetBorrowedBooks(memberId);
        return borrowedBooks;
    }

}
