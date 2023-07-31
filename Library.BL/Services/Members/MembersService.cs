using Library.DAL;

namespace Library.BL;

public class MembersService : IMembersService
{
    private readonly IUnitOfWork _unitOfWork;
    public MembersService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<MemberReadVM> GetAll()
    {
        var members = _unitOfWork.MembersRepo.GetAll()
           .Select(m => new MemberReadVM
           {
              Id = m.Id.ToString(),
              UserName = m.UserName,  
           });
        return members;
    }
    public MemberDetailsVM GetDetails(Guid id)
    {
        Member? member = _unitOfWork.MembersRepo.GetByIdWithBooks(id);
        if (member is null) return null!;
        return new MemberDetailsVM
        {
            Id =  member.Id.ToString() ,
            UserName = member.UserName,
            Books = member.BookMembers?.Select(b => new BookChildVM
            {
               Id=b.BookID.ToString(),
               Title=b.Book!.Title
            })
        };
    }
    public Request Add(MemberAddVM memberVM)
    {
        if (_unitOfWork.MembersRepo.CheckExistingUserName(memberVM.UserName))
        {
            return new Request { Status = false, Message = Message.MemberUserName };
        }
        Member? member = new()
        {
            Id = Guid.NewGuid(),
            UserName = memberVM.UserName,
        };
        _unitOfWork.MembersRepo.Add(member);
        _unitOfWork.Save();

        return new Request { Status = true, Message = Message.Success };
    }
    public Request Delete(Guid id)         
    {
        Member? member = _unitOfWork.MembersRepo.GetByIdWithBooks(id);
        if (member is null)
        {
            return new Request { Status = false, Message = Message.NotFound };
        }
        else if (member.BookMembers.Any())
        {
            return new Request { Status = false, Message = Message.MemberDelete };
        }

        _unitOfWork.MembersRepo.Delete(member);
        _unitOfWork.Save();
        return new Request { Status = true, Message = Message.Success };
    }
}
