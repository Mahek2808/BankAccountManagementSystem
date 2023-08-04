using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountsController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BankAccountResponse>>> GetBankAccounts()
        {
            var bankAccounts = await _bankAccountService.GetBankAccounts();
            return Ok(bankAccounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountResponse>> GetBankAccountById(Guid id)
        {
            var bankAccount = await _bankAccountService.GetBankAccountById(id);
            if (bankAccount != null)
            {
                return Ok(bankAccount);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBankAccount()
        {
            var bankAccountDetails = await _bankAccountService.CreateBankAccount();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBankAccount(Guid id, BankAccountResponse bankAccountVM)
        {
            await _bankAccountService.UpdateBankAccount(id, bankAccountVM);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBankAccount(Guid id)
        {
            await _bankAccountService.DeleteBankAccount(id);
            return NoContent();
        }
    }
}
