
namespace Library.BL;

public interface IMembersService
{
    IEnumerable<MemberReadVM> GetAll();
    MemberDetailsVM GetDetails(Guid id);
    Request Add(MemberAddVM memberVM);
    Request Delete(Guid id);
}
