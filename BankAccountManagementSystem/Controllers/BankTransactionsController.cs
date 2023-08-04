using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankTransactionsController : ControllerBase
    {
        private readonly ITransactionService _bankTransactionService;
        private readonly IBankAccountService _bankAccountService;

        public BankTransactionsController(ITransactionService bankTransactionService, IBankAccountService bankAccountService)
        {
            _bankTransactionService = bankTransactionService;
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BankTransactionResponse>>> GetBankTransactions()
        {
            var bankTransactions = await _bankTransactionService.GetBankTransactions();
            return bankTransactions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankTransactionResponse>> GetBankTransactionById(Guid id)
        {
            BankTransactionResponse result = new();
            var bankTransaction = await _bankTransactionService.GetBankTransactionById(id);
            if (bankTransaction != null)
            {
                result = bankTransaction;
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBankTransaction()
        {
            List<BankAccountResponse> bankAccountList = await _bankAccountService.GetBankAccounts();
            await _bankTransactionService.CreateBankTransaction(bankAccountList);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBankTransaction(Guid id, BankTransactionResponse bankTransactionVM)
        {
            await _bankTransactionService.UpdateBankTransaction(id, bankTransactionVM);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBankTransaction(Guid id)
        {
            await _bankTransactionService.DeleteBankTransaction(id);
            return NoContent();
        }
    }
}
