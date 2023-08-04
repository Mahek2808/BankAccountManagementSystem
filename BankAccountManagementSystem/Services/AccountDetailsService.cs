using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Model;
using BankAccountManagementSystem.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using BankAccountManagementSystem.ViewModel;
using BankAccountManagementSystem.Repository;
using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.Interface.IRepository;

namespace BankAccountManagementSystem.Services
{
    public class AccountDetailsService : IBankAccountService
    {
        private readonly IBankRepository _bankAccountRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ContextClass _contextClass;

        public AccountDetailsService(IBankRepository bankAccountRepository, IMapper mapper, IConfiguration configuration, ContextClass contextClass)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
            _configuration = configuration;
            _contextClass = contextClass;
        }

        public async Task<List<BankAccountResponse>> GetBankAccounts()
        {
            var bankAccounts = await _bankAccountRepository.GetBankAccounts();
            return _mapper.Map<List<BankAccountResponse>>(bankAccounts);
        }

        public async Task<BankAccountResponse> GetBankAccountById(Guid id)
        {
            var bankAccount = await _bankAccountRepository.GetBankAccountById(id);
            return _mapper.Map<BankAccountResponse>(bankAccount);
        }

        public async Task<List<BankAccountResponse>> CreateBankAccount()
        {
            var bankAccountList = new List<BankAccountResponse>();
            try
            {
                List<BankAccount> bankAccounts = new List<BankAccount>();
                // Create dummy BankAccounts
                var random = new Random();
                string DBBankAccountConn = _configuration.GetValue<string>("DummyRecord:NumberOfBankAccounts");
                var randomPaymentMethod = _contextClass.PaymentDetails.OrderBy(x => Guid.NewGuid()).First();
                var randomAccountType = _contextClass.AccountTypesDetails.OrderBy(y => Guid.NewGuid()).First();

                for (int i = 0; i < int.Parse(DBBankAccountConn); i++)
                {
                    DateTime accountOpeningDate = DateTime.Now.AddDays(-random.Next(1, 365));
                    var account = new BankAccount
                    {
                        Id = Guid.NewGuid(),
                        FirstName = $"First{i}",
                        MiddleName = $"Middle{i}",
                        LastName = $"Last{i}",
                        AccountNumber = random.Next(10000000, 99999999), // Generate 8-digit number
                        AccountOpeningDate = accountOpeningDate,
                        AccountClosingDate = DateTime.Now.AddDays(-random.Next(0, ((DateTime.Now - accountOpeningDate).Days + 1))),
                        AccountType = randomAccountType,
                    };
                    bankAccounts.Add(account);
                }
                await _bankAccountRepository.CreateDummyBankAccount(bankAccounts);
                bankAccountList = _mapper.Map<List<BankAccountResponse>>(bankAccounts);
            }
            catch (Exception ex)
            {
                throw;
            }
            return bankAccountList;
        }

        public async Task UpdateBankAccount(Guid id, BankAccountResponse bankAccountVM)
        {
            var existingBankAccount = await _bankAccountRepository.GetBankAccountById(id);
            if (existingBankAccount == null)
            {
                // Handle not found scenario
                throw new Exception("Bank account not found.");
            }
            _mapper.Map(bankAccountVM, existingBankAccount);
            await _bankAccountRepository.UpdateBankAccount(id, existingBankAccount);
        }

        public async Task DeleteBankAccount(Guid id)
        {
            var existingBankAccount = await _bankAccountRepository.GetBankAccountById(id);
            if (existingBankAccount == null)
            {
                // Handle not found scenario
                throw new Exception("Bank account not found.");
            }
            await _bankAccountRepository.DeleteBankAccount(id);
        }
    }
}


