using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;

        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountTypeResponse>>> GetAccountType()
        {
            var paymentMethods = await _accountTypeService.GetAccountType();
            return Ok(paymentMethods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTypeResponse>> GetAccountTypeById(Guid id)
        {
            var paymentMethod = await _accountTypeService.GetAccountTypeById(id);
            if (paymentMethod != null)
            {
                return Ok(paymentMethod);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAccountType(Guid id, AccountTypeResponse accountType)
        {
            await _accountTypeService.UpdateAccountType(id, accountType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccountType(Guid id)
        {
            await _accountTypeService.DeleteAccountType(id);
            return NoContent();
        }
    }
}
