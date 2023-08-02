using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface;
using BankAccountManagementSystem.Model;
using BankAccountManagementSystem.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace BankAccountManagementSystem.Services
{
    public class AccountDetailsService : IBankAccount
    {
        public readonly ContextClass _context;
        public readonly IConfiguration configuration;
        public AccountDetailsService(ContextClass context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public async Task<List<BankAccount>> GetAllBankAccounts()
        {
            var accntRecords = _context.BankAccountsDetails.ToList();
            return accntRecords;
        }

        public async Task CreateDummyDataForBankAccount()
        {
            try
            {
                // Create dummy Account Type
                var accountTypes = new List<AccountType>
                {
                    new AccountType { AccountTypeId = Guid.NewGuid(), TypeOfAccount = BankAccountType.Liability },
                    new AccountType { AccountTypeId = Guid.NewGuid(), TypeOfAccount = BankAccountType.Asset }
                };

                    // Create dummy Payment Methods
                    var paymentMethods = new List<Payment>
                {
                    new Payment { PaymentId = Guid.NewGuid(), NameOfPaymentType = PaymentType.Cash },
                    new Payment { PaymentId = Guid.NewGuid(), NameOfPaymentType = PaymentType.Cheque },
                    new Payment { PaymentId = Guid.NewGuid(), NameOfPaymentType = PaymentType.NEFT },
                    new Payment { PaymentId = Guid.NewGuid(), NameOfPaymentType = PaymentType.RTGS },
                    new Payment { PaymentId = Guid.NewGuid(), NameOfPaymentType = PaymentType.Other }
                };

                _context.AccountTypesDetails.AddRange(accountTypes);
                _context.PaymentDetails.AddRange(paymentMethods);
                _context.SaveChanges();

                // Create dummy BankAccounts
                var random = new Random();
                string DBBankAccountConn = configuration.GetValue<string>("DummyRecord:NumberOfBankAccounts");
                var bankAccounts = new List<BankAccount>();
                var randomPaymentMethod = _context.PaymentDetails.OrderBy(x => Guid.NewGuid()).First();
                var randomAccountType = _context.AccountTypesDetails.OrderBy(y => Guid.NewGuid()).First();

                for (int i = 0; i < int.Parse(DBBankAccountConn); i++)
                {
                    DateTime accountOpeningDate = DateTime.Now.AddDays(-random.Next(1, 365));
                    var account = new BankAccount
                    {
                        BankAccountId = Guid.NewGuid(),
                        FirstName = $"First{i}",
                        MiddleName = $"Middle{i}",
                        LastName = $"Last{i}",
                        AccountNumber = random.Next(10000000, 99999999), // Generate 8-digit number
                        AccountOpeningDate = accountOpeningDate,                   
                        AccountClosingDate = DateTime.Now.AddDays(-random.Next(0, ((DateTime.Now - accountOpeningDate).Days + 1))),
                        AccountType = randomAccountType,
                        TotalAmountOfBalance = 100
                    };
                    await _context.BankAccountsDetails.AddAsync(account);
                    bankAccounts.Add(account);
                    _context.BankAccountsDetails.Add(account);
                }
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                ex.Source = "Error Occuerd while adding BankAccount";
            }
        }

    }
}


