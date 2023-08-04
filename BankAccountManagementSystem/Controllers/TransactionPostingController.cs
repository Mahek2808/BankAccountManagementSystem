using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionPostingController : ControllerBase
    {
        private readonly IPostingService _PostingService;
        private readonly ITransactionService _transactionService;

        public TransactionPostingController(IPostingService bankAccountPostingService, ITransactionService transactionService)
        {
            _PostingService = bankAccountPostingService;
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccountPostingDetailResponse>>> GetBankAccountPostings()
        {
            List<BankTransactionResponse> bankAccountList = await _transactionService.GetBankTransactions();
            await _PostingService.GetBankAccountPostings(bankAccountList);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountPostingDetailResponse>> GetBankAccountPostingById(Guid id)
        {
            var bankAccountPosting = await _PostingService.GetBankAccountPostingById(id);
            if (bankAccountPosting == null)
            {
                return Ok(bankAccountPosting);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBankAccountPosting(Guid id)
        {
                await _PostingService.DeleteBankAccountPosting(id);
                return Ok("Message Deleted Sucessecfully");           
        }
    }
}
