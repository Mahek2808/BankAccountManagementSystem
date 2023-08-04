using BankAccountManagementSystem.Model;

namespace BankAccountManagementSystem.Interface.IRepository
{
    public interface IPostngRepository
    {
        Task<List<BankAccountPostingDetail>> GetBankAccountPostings();
        Task<BankAccountPostingDetail> GetBankAccountPostingById(Guid id);
        Task DeleteBankAccountPosting(Guid id);
    }
}
