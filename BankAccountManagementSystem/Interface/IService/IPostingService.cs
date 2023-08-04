using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Interface.IService
{
    public interface IPostingService
    {
        Task<List<BankAccountPostingDetailResponse>> GetBankAccountPostings(List<BankTransactionResponse> bankTransactions);
        Task<BankAccountPostingDetailResponse> GetBankAccountPostingById(Guid id);
        Task DeleteBankAccountPosting(Guid id);
    }
}
