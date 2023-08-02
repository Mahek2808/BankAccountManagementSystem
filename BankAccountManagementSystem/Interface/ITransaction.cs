using BankAccountManagementSystem.Model;

namespace BankAccountManagementSystem.Interface
{
    public interface ITransaction
    {
        Task CreateDummyDataForTransaction(List<BankAccount> bankAccounts);
        Task<List<BankTransaction>> GetAllTransaction();
        Task<BankTransaction> GetBankAccountWithTransactions(Guid transactionId);
    }
}
