using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagementSystem.Repository
{
    public class TransactionPostingRepository : IPostngRepository
    {
        private readonly ContextClass _ContextClass;

        public TransactionPostingRepository(ContextClass contextClass)
        {
            _ContextClass = contextClass;
        }
        public async Task<BankAccountPostingDetail> GetBankAccountPostingById(Guid id)
        {
            return await _ContextClass.BankAccountPostingDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<BankAccountPostingDetail>> GetBankAccountPostings()
        {
            return await _ContextClass.BankAccountPostingDetails.ToListAsync();
        }
        public async Task DeleteBankAccountPosting(Guid id)
        {
            var existingPosting = await GetBankAccountPostingById(id);
            if (existingPosting != null)
            {
                _ContextClass.Remove(existingPosting);
            }
        }
    }
}
