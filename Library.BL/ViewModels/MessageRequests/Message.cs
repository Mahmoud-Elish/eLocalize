
namespace Library.BL;

public static class Message
{
    public const string Status = "Status";
    public const string Mess = "Message";
    public const string Success = "Success";
    public const string NotFound = "NotFound";
    public const string BookTitle = "This book title already exists";
    public const string BookQuantity = "It is difficult to modify the quantity since there is very little available quantity.";
    public const string BookDelete = "Unable to delete book since it is a borrowed book.";
    public const string MemberUserName = "This User Name already exists";
    public const string MemberDelete = "Member cannot be deleted since has borrowed books.";
    public const string Borrow = "You already borrowed the book";
    public const string Books = "There aren't enough copies of the book available.";
    public const string Lend = "The book is not borrowed until you return it";
}
