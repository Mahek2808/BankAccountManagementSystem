using AutoMapper;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly IMapper _mapper;

        public AccountTypeService(IAccountTypeRepository accountTypeRepository, IMapper mapper)
        {
            _accountTypeRepository = accountTypeRepository;
            _mapper = mapper;
        }

        public async Task DeleteAccountType(Guid id)
        {
            var existingMethod = await _accountTypeRepository.GetAccountTypeById(id);
            if (existingMethod != null)
            {
                await _accountTypeRepository.DeleteAccountType(id);
            }
            throw new Exception("Payment method not found.");
        }

        public async Task<List<AccountTypeResponse>> GetAccountType()
        {
            var accountType = await _accountTypeRepository.GetAccountType();
            return _mapper.Map<List<AccountTypeResponse>>(accountType);
        }

        public async Task<AccountTypeResponse> GetAccountTypeById(Guid id)
        {
            var accountTypeById = await _accountTypeRepository.GetAccountTypeById(id);
            return _mapper.Map<AccountTypeResponse>(accountTypeById);
        }

        public async Task UpdateAccountType(Guid id, AccountTypeResponse accountType)
        {
            var existingMethod = await _accountTypeRepository.GetAccountTypeById(id);
            if (existingMethod != null)
            {
                _mapper.Map(accountType, existingMethod);
                await _accountTypeRepository.UpdateAccountType(id, existingMethod);
            }
            throw new Exception("Payment method not found.");
        }
    }
}
