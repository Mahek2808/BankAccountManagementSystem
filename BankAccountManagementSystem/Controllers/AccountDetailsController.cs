using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface;
using BankAccountManagementSystem.Model;
using BankAccountManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly IBankAccount _accountDetailsService;
        private readonly ContextClass _contextClass;
        private readonly ITransaction _transactionDetailService;

        public AccountDetailsController(IBankAccount accountDetailsService,ContextClass contextClass, ITransaction transactionService)
        {
            _accountDetailsService = accountDetailsService;
            _contextClass = contextClass;
            _transactionDetailService = transactionService;
        }

        [HttpGet("GetBankAccounts")]
        public IActionResult GetBankAccounts()
        {
            try
            {
                var bankAccounts = _accountDetailsService.GetAllBankAccounts();
                return Ok(bankAccounts);
            }
            catch (Exception ex)
            {
                // Handle exception here and return appropriate response
                return StatusCode(500, "An error occurred while fetching bank accounts.");
            }
        }

        [HttpGet("GetBankAccountWithTransactions/{bankAccountId}")]
        public async Task<IActionResult> GetBankAccountWithTransactions(Guid bankAccountId)
        {
            try
            {
                var bankAccount = await _transactionDetailService.GetBankAccountWithTransactions(bankAccountId);
                if (bankAccount == null)
                {
                    return NotFound("Bank account not found.");
                }

                return Ok(bankAccount);
            }
            catch (Exception ex)
            {
                // Handle exception here and return appropriate response
                return StatusCode(500, "An error occurred while fetching bank account.");
            }
        }

        [HttpGet("GetTransaction")]
        public IActionResult GetTransaction()
        {
            try
            {
                var transaction = _transactionDetailService.GetAllTransaction();
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                // Handle exception here and return appropriate response
                return StatusCode(500, "An error occurred while fetching bank accounts.");
            }
        }

        [HttpPost("CreateDummyDataForBankAccount")]
        public async Task<IActionResult> CreateDummyDataForBankAccount()
        {
            try
            { 
                await _accountDetailsService.CreateDummyDataForBankAccount();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating dummy data of BankAccount.");
            }
        }


        [HttpPost("CreateDummyDataForTransaction")]
        public async Task<IActionResult> CreateDummyDataForTransaction()
        {
            try
            {
                List<BankAccount> bankAccounts = await _accountDetailsService.GetAllBankAccounts();
                await _transactionDetailService.CreateDummyDataForTransaction(bankAccounts);
                return Ok();
            }
            catch (Exception ex)
            {  
                return StatusCode(500, "An error occurred while creating dummy data of Transaction.");
            }
        }

    }
}
