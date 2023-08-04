using AutoMapper;
using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Enum;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.Model;
using BankAccountManagementSystem.ViewModel;
using System.Transactions;

namespace BankAccountManagementSystem.Services
{
    public class TransactionDetailsService : ITransactionService
    {
        private readonly ITransactionRepository _bankTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ContextClass _contextClass;

        public TransactionDetailsService(ITransactionRepository transactionRepository, IMapper mapper, IConfiguration configuration, ContextClass contextClass)
        {
            _bankTransactionRepository = transactionRepository;
            _mapper = mapper;
            _configuration = configuration;
            _contextClass = contextClass;
        }

        public async Task<List<BankTransactionResponse>> GetBankTransactions()
        {
            var bankTransactions = await _bankTransactionRepository.GetBankTransactions();
            return _mapper.Map<List<BankTransactionResponse>>(bankTransactions);
        }

        public async Task<BankTransactionResponse> GetBankTransactionById(Guid id)
        {
            try
            {
                var bankTransaction = await _bankTransactionRepository.GetBankTransactionById(id);
                return _mapper.Map<BankTransactionResponse>(bankTransaction);
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }

        public async Task<List<BankTransactionResponse>> CreateBankTransaction(List<BankAccountResponse> bankAccounts)
        {
            var bankTransactionList = new List<BankTransactionResponse>();
            var transactions = new List<BankTransaction>();
            try
            {

                foreach (var bankAccount in bankAccounts)
                {
                    var random = new Random();
                    decimal CreditAmount = 0;
                    decimal DebitAmount = 0;
                    string DBTransactionConn = _configuration.GetValue<string>("DummyRecord:NumberOfBankTransactions");
                    for (int j = 0; j < int.Parse(DBTransactionConn); j++)
                    {
                        var randomPaymentMethod = _contextClass.PaymentDetails.OrderBy(x => Guid.NewGuid()).First();
                        var randomCategoryOption = Enum.CatagoryOptionsForBankAccount.GetValues(typeof(CatagoryOptionsForBankAccount)).Cast<CatagoryOptionsForBankAccount>().OrderBy(x => random.Next()).First();
                        var amount = (decimal)random.NextDouble() * 1000; // Random amount up to 1000
                        var transactionType = random.Next(0, 2) == 0 ? TransactionType.Credit : TransactionType.Debit;

                        var transaction = new BankTransaction
                        {
                            Id = Guid.NewGuid(),
                            FirstName = bankAccount.FirstName,
                            MiddleName = bankAccount.MiddleName,
                            LastName = bankAccount.LastName,
                            TypeOfTransaction = random.Next(0, 2) == 0 ? TransactionType.Credit : TransactionType.Debit,
                            CatagoryOptions = randomCategoryOption,
                            Amount = amount,
                            DateOfTransaction = bankAccount.AccountOpeningDate.AddDays(random.Next(1, 365)), // Random date after the opening date
                            Payment = randomPaymentMethod,
                            BankAccount_Id = bankAccount.Id
                        };

                        if (transaction.TypeOfTransaction == TransactionType.Credit)
                        {
                            CreditAmount += transaction.Amount; //(decimal)random.NextDouble() * 1000; // Random amount up to 1000
                        }
                        else if (transaction.Amount < bankAccount.TotalAmountOfBalance)
                        {
                            var debitAmount = Math.Min(transaction.Amount, 50);
                            DebitAmount -= debitAmount;
                        }
                        else
                        {
                            var fixtedDebitAmount = 10;
                            DebitAmount -= fixtedDebitAmount;
                        }

                        transactions.Add(transaction);
                        bankAccount.TotalAmountOfBalance += (int)(Math.Abs(CreditAmount) - Math.Abs(DebitAmount));
                        _contextClass.BankTransactionDetails.Add(transaction);

                        if (randomCategoryOption == CatagoryOptionsForBankAccount.BankIntrest || randomCategoryOption == CatagoryOptionsForBankAccount.BankCharges)
                        {
                            // This is for BankAccountPosting table
                            var posting = new BankAccountPostingDetail
                            {
                                Id = Guid.NewGuid(),
                                BankTransaction_Id = transaction.Id
                            };
                            _contextClass.BankAccountPostingDetails.Add(posting);
                        }
                    }
                    bankAccount.TotalAmountOfBalance = (int)(Math.Abs(CreditAmount) - Math.Abs(DebitAmount));
                }
                await _bankTransactionRepository.CreateBankTransaction(transactions);
                return _mapper.Map<List<BankTransactionResponse>>(transactions);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateBankTransaction(Guid id, BankTransactionResponse bankTransactionVM)
        {
            var existingBankTransaction = await _bankTransactionRepository.GetBankTransactionById(id);
            if (existingBankTransaction == null)
            {
                throw new Exception("Bank transaction not found.");
            }
            _mapper.Map(bankTransactionVM, existingBankTransaction);

            await _bankTransactionRepository.UpdateBankTransaction(id, existingBankTransaction);
        }

        public async Task DeleteBankTransaction(Guid id)
        {
            var existingBankTransaction = await _bankTransactionRepository.GetBankTransactionById(id);
            if (existingBankTransaction == null)
            {
                // Handle not found scenario
                throw new Exception("Bank transaction not found.");
            }

            await _bankTransactionRepository.DeleteBankTransaction(id);
        }
    }
}
