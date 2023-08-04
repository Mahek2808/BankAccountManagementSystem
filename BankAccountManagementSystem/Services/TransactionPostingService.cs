using AutoMapper;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Services
{
    public class TransactionPostingService : IPostingService
    {
        private readonly IPostngRepository _PostingRepository;
        private readonly IMapper _mapper;

        public TransactionPostingService(IPostngRepository PostingRepository, IMapper mapper)
        {
            _PostingRepository = PostingRepository;
            _mapper = mapper;
        }
        public async Task<BankAccountPostingDetailResponse> GetBankAccountPostingById(Guid id)
        {
            var bankAccountPosting = await _PostingRepository.GetBankAccountPostingById(id);
            return _mapper.Map<BankAccountPostingDetailResponse>(bankAccountPosting);
        }

        public async Task<List<BankAccountPostingDetailResponse>> GetBankAccountPostings(List<BankTransactionResponse> bankTransactions)
        {
            var bankAccountPostings = await _PostingRepository.GetBankAccountPostings();
            return _mapper.Map<List<BankAccountPostingDetailResponse>>(bankAccountPostings);
        }

        public async Task DeleteBankAccountPosting(Guid id)
        {
            var existingPosting = await _PostingRepository.GetBankAccountPostingById(id);
            if (existingPosting == null)
            {
                // Handle not found scenario
                throw new Exception("Bank account posting not found.");
            }

            await _PostingRepository.DeleteBankAccountPosting(id);
        }
    }
}
